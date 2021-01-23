    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Attribute routing.
            config.MapHttpAttributeRoutes();
    
            // Convention-based routing.
    
            config.Routes.MapHttpRoute(
                name: "MyApi",
                routeTemplate: "api/users/{action}",
                defaults: new { controller = "Users" }
            );
    
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
