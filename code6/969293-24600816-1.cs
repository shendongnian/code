    public class RouteConfig
    {
       public static void RegisterRoute(RouteCollection routes)
       {
          routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
    
          routes.MapRoute("Home", "", new { Controller = "Home", Action = "Index" });
    
          route.MapRoute(
             "Default",
             "{controller}/{action}",
             new {controller = "Home", action = "Index"}
          );
       }
    }
