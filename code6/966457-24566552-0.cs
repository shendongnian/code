    public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
            routes.MapRoute(
                name: "Secure",
                url: "{session_id}/{controller}/{action}"
                defaults: new 
                { 
                    session_id=string.Empty,
                    controller = "Home", 
                    action = "Index"
                }
            );
        }
