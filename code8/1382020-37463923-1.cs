        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "CompanyRouteWithoutParameters",
                "{company}/{controller}/{action}",
                new { controller = "Home", action = "Index" },
                new { company = new RouteValidation() }
            );
            routes.MapRoute(
                "CompanyRouteWithParameters",
                "{company}/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
