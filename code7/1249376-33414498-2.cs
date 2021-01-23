        public class LandingPageRouteHandler : MvcRouteHandler
        {
            protected override IHttpHandler GetHttpHandler(RequestContext Context)
            {
                if (  Context.HttpContext.Request.Url.DnsSafeHost.ToLower().Contains("onecityguide"))
                {
                    Context.RouteData.Values["controller"] = "LandingPage";
                    Context.RouteData.Values["action"] = "Index"; 
                    Context.RouteData.Values["id"] = "onecityguide";
                }
                return base.GetHttpHandler(Context);
            }
        }
