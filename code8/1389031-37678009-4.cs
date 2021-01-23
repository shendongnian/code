    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Attribute routing.
            config.MapHttpAttributeRoutes();
    
            // Convention-based routing.
    
            config.Routes.MapHttpRoute(
                name: "MyApi",
                routeTemplate: "api/{controller}/{action}/{value}",
                defaults: new { value = RouteParameter.Optional }
            );
    
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
