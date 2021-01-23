    using LowercaseRoutesMVC
     ...
    
    public static void RegisterRoutes(RouteCollection routes)
    {
       routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
       routes.MapRouteLowercase( // changed from routes.MapRoute
           "Default",
           "{controller}/{action}/{id}",
           new { controller = "Home", action = "Index", id = UrlParameter.Optional }
       );
    }
