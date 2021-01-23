    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Removing XML
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Allows us to map routes using [Route()] and [RoutePrefix()]
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
