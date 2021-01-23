    public class RouteConfig
    {
       public static void RegisterRoute(RouteCollection routes)
       {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
        route.MapRoute(
         name: "Default",
         url: "{controller}/{action}/{id}",
         defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional }
          );
       }
    }
