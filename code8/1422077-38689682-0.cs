    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Attribute routing.
            config.MapHttpAttributeRoutes();
            // Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "ServicesApi",
                routeTemplate: "api/store/{id}/services",
                defaults: new { controller = "Services" }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
