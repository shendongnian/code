    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "CPDPlanRoutes",
                url: "mypage/{action}/{planId}",
                defaults: new { controller = "CPDPlanSurface", action = "Index", planId = UrlParameter.Optional });
        }
    }
