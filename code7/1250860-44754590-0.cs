    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    
    namespace WebApplication2
    {
        public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                // Web API configuration and services
    
                // Web API routes
                config.MapHttpAttributeRoutes();
    
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
    
                // Load Web API controllers and Azure Storage store
                config.InitializeCustomWebHooks();
                config.InitializeCustomWebHooksAzureStorage();
                config.InitializeCustomWebHooksApis();
                config.InitializeReceiveCustomWebHooks();
            }
        }
    }
