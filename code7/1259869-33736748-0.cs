    public static class Url
    {
        public static bool IsWebApiRequest()
        {
            return
                HttpContext.Current.Request.RequestContext.HttpContext.CurrentHandler is
                    System.Web.Http.WebHost.HttpControllerHandler;
        }
        public static string RouteUrl(string routeName, object routeValues = null)
        {
            var url = String.Empty;
            try
            {
                var helper = new System.Web.Http.Routing.UrlHelper();
                return helper.Link(routeName, routeValues);             
            }
            catch
            {
                return url;
            }
        }
        public static string HttpRouteUrl(string routeName, object routeValues = null)
        {
            var url = String.Empty;
            try
            {
                var helper = new System.Web.Mvc.UrlHelper();
                return helper.HttpRouteUrl(routeName, routeValues);
            }
            catch
            {
                return url;
            }
        }
    }
