    public static void RegisterRoutes(RouteCollection routes)
    {    
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapMvcAttributeRoutes();
        
        //Custom and default route definitions goes here
    }
