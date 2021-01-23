      public static void RegisterRoutes(RouteCollection routes)
        {
          routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        
          routes.MapRoute(
            "Default",                                              // Route name
            "{controller}/{action}/{id}",                           // URL
            new { controller = "Home", action = "Index", id = "" }, // Defaults
            new[]{"AreasDemoWeb.Controllers"}                       // Namespaces
          );
        }
