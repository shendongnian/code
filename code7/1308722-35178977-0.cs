    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            Log.Instance().Debug("Registering Routes");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
