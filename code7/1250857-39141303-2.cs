    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Make sure the assembly Microsoft.AspNet.WebHooks.Receivers is loaded
            var controllerType = typeof (WebHookReceiversController);
            
            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // Load Web API controllers 
            config.InitializeCustomWebHooks();
            config.InitializeCustomWebHooksApis();
            config.InitializeReceiveCustomWebHooks();
        }
    }
