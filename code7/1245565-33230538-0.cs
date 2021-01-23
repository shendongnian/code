    public class MvcApplication : System.Web.HttpApplication
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
                routes.MapRoute(
                    "Vessels",                                              // Route name
                    "Ship/{action}/{id}",                                   // URL with parameters
                    new { controller = "Vessel", id = "" }                  // Parameter defaults
                );
    
                routes.MapRoute(
                    "Default",                                              // Route name
                    "{controller}/{action}/{id}",                           // URL with parameters
                    new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
                );
    
            }
    
            protected void Application_Start()
            {
                RegisterRoutes(RouteTable.Routes);
            }
        }
