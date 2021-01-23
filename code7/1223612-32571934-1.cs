    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "XmlSitemap",
                url: "blog/sitemap.xml",
                defaults: new { controller = "XmlSiteMap", action = "Index", page = 0 }
            );
            routes.MapRoute(
                name: "XmlSitemap-Paged",
                url: "blog/sitemap-{page}.xml",
                defaults: new { controller = "XmlSiteMap", action = "Index", page = 0 }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
