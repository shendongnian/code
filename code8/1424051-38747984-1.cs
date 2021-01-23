    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
      routes.MapRoute(
        name: "Admin",
        url: "Admin/{action}/{id}",
        defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
      );
      routes.MapRoute(
        name: "Default",
        url: "{url}/{action}",
        defaults: new { controller = "Default", action = "Index", url = UrlParameter.Optional }
      );
    }
