    public static void RegisterRoutes(RouteCollection routes)
    {            
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapMvcAttributeRoutes(); //This line enables attribute routing 
       //Existing default Route definition goes here
    }
