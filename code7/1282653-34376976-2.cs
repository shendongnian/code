    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Ignore unwanted routes first
            routes.IgnoreRoute("{area}/Default");
            routes.IgnoreRoute("{area}/Default/Index");
            // Then register your areas (move this line here from Global.asax)
            AreaRegistration.RegisterAllAreas();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
