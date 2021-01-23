    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.Add("Categories", new CachedRoute<int>(
                controller: "Category", 
                action: "Index", 
                dataProvider: new CategoryCachedRouteDataProvider(new CategorySlugBuilder())));
            routes.Add("Products", new CachedRoute<int>(
                controller: "Product",
                action: "Index",
                dataProvider: new ProductCachedRouteDataProvider(new CategorySlugBuilder())));
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
