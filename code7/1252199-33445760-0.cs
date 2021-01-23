    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
        routes.MapRoute(
            "Default",
            "{controller}/{action}/{id}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            new { controller = "Home|Account" }
        );
    
        routes.MapRoute(
            "CustomRoute",
            "{*urlSegment}",
            new { controller = "MyController", action = "SomeAction" }
        );
    }
