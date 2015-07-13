using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Web.Http;
using tomhonCarDealer.DataObjects;
using tomhonCarDealer.Models;
using Microsoft.WindowsAzure.Mobile.Service;

namespace tomhonCarDealer
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            Database.SetInitializer(new MobileServiceInitializer());
        }
    }

    public class MobileServiceInitializer : DropCreateDatabaseIfModelChanges<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
            List<Job> todoItems = new List<Job>
            {
                new Job { Id = Guid.NewGuid().ToString(), Title = "First item", Complete = false },
                new Job { Id = Guid.NewGuid().ToString(), Title = "Second item", Complete = false },
            };

            foreach (Job todoItem in todoItems)
            {
                context.Set<Job>().Add(todoItem);
            }

            base.Seed(context);
        }
    }
}

