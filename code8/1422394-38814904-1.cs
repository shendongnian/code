    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
            name: "Default",
            url: "web/{controller}/{action}/{id}",
            defaults: new { controller = "Parking", action = "Get", id = UrlParameter.Optional }
        );
    }
