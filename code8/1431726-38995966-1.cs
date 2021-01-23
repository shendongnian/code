    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            
            config.Routes.MapHttpRoute(
                name: "DisabledApi",
                routeTemplate: "api/b/{id}",
                defaults: new { controller = "DoesNotExist", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
