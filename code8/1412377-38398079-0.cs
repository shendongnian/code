    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Country",
                url: "/Controllers/Index",
                defaults: new { controller = "CommonController", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "State",
                url: "/CDS/Controllers/Details/5",
                defaults: new { controller = "CommonController", action = "Details", id = UrlParameter.Optional }
            );
        }
    }
