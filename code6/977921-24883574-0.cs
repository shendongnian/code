     public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                config.MapHttpAttributeRoutes();
    
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "web/{controller}/{action}/{datetime}",
                    defaults: new { controller = "API", datetime = RouteParameter.Optional }
                );
    
                config.BindParameter(typeof(DateTime), new CurrentCultureDateTimeAPI());
            }
