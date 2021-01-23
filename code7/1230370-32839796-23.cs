    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Call to register your localized and default attribute routes
            routes.MapLocalizedMvcAttributeRoutes(
                urlPrefix: "{culture}/", 
                constraints: new { culture = new CultureConstraint(defaultCulture: "nl", pattern: "[a-z]{2}") });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
