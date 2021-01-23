    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // This route should go first
            routes.Add(
                name: "IgnoreQuery",
                item: new IgnoreQueryStringKeyRoute("_escaped_fragment_"));
            // Any other routes should be registered after...
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
