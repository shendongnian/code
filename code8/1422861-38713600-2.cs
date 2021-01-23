    public static void RegisterRoutes(RouteCollection routes) {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        
        //This will map routes from Route attribute.
        routes.MapMvcAttributeRoutes();
    
        // ...
    }
