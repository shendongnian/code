    public class RouteConfig {
    
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Default",                                                  // Route name 
                template: "{controller}/{action}/{id}",                           // template with parameters 
                defaults: new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
    
            // You could add other routes as needed, but
            // pay attention to the order in which 
            // you add them as that is important
            // when it comes to matching routes
        }
    }
