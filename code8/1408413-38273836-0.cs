        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            var pageList = new PageService().Get();
            foreach (var page in pageList)
            {
                var targetRoute = string.Format("{1}/{2}", page.PageArea, page.PageController, page.PageAction);
                if (!string.IsNullOrWhiteSpace(page.PageArea))
                    targetRoute = string.Format("{0}/{1}/{2}", page.PageArea, page.PageController, page.PageAction);
                routes.MapRoute(
                    string.Format("PageBuilder_{0}", page.PageId),
                    targetRoute,
                    new { area = "Builder", controller = "Build", action = "Index", pageId = page.PageId }
                );
            }
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
