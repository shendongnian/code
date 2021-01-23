    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}",
            defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
        );
        }
    }
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
    
            config.Routes.MapHttpRoute(
                name: "DefaultDataApi",
                routeTemplate: "Api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
