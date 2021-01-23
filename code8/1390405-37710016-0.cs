    private static string MvcURL(string routeName, string controller, object routeValues)
    {
        var urlHelper = new System.Web.Mvc.UrlHelper(
            new RequestContext(
                new HttpContextWrapper(HttpContext.Current),
                HttpContext.Current.Request.RequestContext.RouteData), 
            RouteTable.Routes);
        return urlHelper.Action(routeName, controller, routeValues, HttpContext.Current.Request.Url.Scheme);
    }
