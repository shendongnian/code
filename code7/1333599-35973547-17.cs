        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // New MapRoute for your 40+ files..
            routes.MapRoute(
                "OrdeForm",
                "OrderForm/{file}",
                new { controller = "MyController", action = "Page", {file} = "" }
            );
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = "" }
            );
        }
