    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default_Localized",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { culture = new CultureConstraint(defaultCulture: "en", pattern: "[a-z]{2}") },
                namespaces: new string[] { "Locator.Areas.Location.Controllers" }
            ).DataTokens["area"] = "Location";
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { culture = "en", controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Locator.Areas.Location.Controllers" }
            ).DataTokens["area"] = "Location";
        }
    }
