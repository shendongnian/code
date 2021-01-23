    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    namespace MvcApplication1
    {
        public static class RouteCollectionExtensions
        {
            public static Route MapRouteWithName(this RouteCollection routes, string name, string url, object defaults)
            {
                Route route = routes.MapRoute(name, url, defaults);
                route.DataTokens = new RouteValueDictionary();
                route.DataTokens.Add("RouteName", name);
    
                return route;
            }
        }
    
    
        public class RouteConfig
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
                routes.MapRouteWithName(
                    "myRouteName",
                    "{controller}/{action}/{username}",
                    new { controller = "Home", action = "List" }
    
                    );
            }
        }
    }
