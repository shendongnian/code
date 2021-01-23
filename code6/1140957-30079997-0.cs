    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            var route = routes.MapRoute(
                name: "WSContext",
                url: "ws_{webservice}",
                defaults: new { controller = "Help", action = "Index" }
            );
            
            route.DataTokens["area"] = "HelpPage";
            route = routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Help", action = "Index", id = UrlParameter.Optional }
            );
            route.DataTokens["area"] = "HelpPage";
        }
    }
