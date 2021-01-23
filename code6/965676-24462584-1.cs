    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        
        // Make sure this line is added
        routes.MapMvcAttributeRoutes();
    }
