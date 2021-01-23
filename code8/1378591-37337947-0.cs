    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            var route = routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "YourController", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "YourDomain.NameSpace.Controllers" }
            );
            route.DataTokens["UseNamespaceFallback"] = true;
        }
    }
