    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.Add(
                name: "DefaultApi",
                route: new ReplacePipeHttpRoute(
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional, controller = "Vehicles" })
            );
        }
    }
