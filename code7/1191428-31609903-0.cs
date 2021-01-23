    public static void RegisterRoutes(RouteCollection routes)
        {
              
            routes.MapRoute(
                "Default", 
                "{controller}/{action}", 
                new { controller = "Home", action = "Login"} 
            );
    
        }
