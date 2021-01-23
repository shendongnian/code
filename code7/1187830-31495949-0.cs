    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "UserRoute",
                url: "{
                         controller}/{action}/{id}/{name}/{age}",
                         defaults: new { 
                                        controller = "Home", 
                                        action = "Index", 
                                        id = UrlParameter.Optional, 
                                        name = UrlParameter.Optional, 
                                        age = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { 
                                 controller = "Home", 
                                 action = "Index", 
                                 id = UrlParameter.Optional }
            );
        }
    }
