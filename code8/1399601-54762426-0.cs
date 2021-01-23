    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.Ignore("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "device", action = "view", id = UrlParameter.Optional });
        }
    }
