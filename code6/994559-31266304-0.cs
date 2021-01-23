        public class ApplicationStartup : ApplicationEventHandler
        {
            protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
            {
    RouteTable.Routes.MapUmbracoRoute("routename", "Ads/{parent}/{child}", new { controller = "AdsController", action = "Index" }, new PublishedPageRouteHandler(PublishedPageId));
    }
