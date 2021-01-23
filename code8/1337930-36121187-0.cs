    public class RouteConfig {
    
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // you can map attribute routes automatically
            routes.MapMvcAttributeRoutes(); //NOTE: This one must come before manual mappings
            // and/or add them manually
            routes.MapRoute(
                name: "Default",                                                  // Route name 
                url: "{controller}/{action}/{id}",                                // URL with parameters 
                defaults: new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
    
            // You could add other routes as needed, but
            // pay attention to the order in which 
            // you add them as that is important
            // when it comes to matching routes
        }
    }
