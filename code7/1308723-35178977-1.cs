    public static class WebApiConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            ConfigureRouting(config);
            ConfigureFormatters(config);
        }
        private static void ConfigureFormatters(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new NiceEnumConverter());
        }
        private static void ConfigureRouting(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional, @namespace = "api" });
        }
    }
