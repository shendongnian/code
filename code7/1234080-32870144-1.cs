    public static MvcHtmlString ActionLinkByRequest(this HtmlHelper helper, RequestBase request, object htmlAttributes = null)
    {
        var rvd = new RouteValueDictionary(request);
        rvd.Remove("ActionName");
        rvd.Remove("ControllerName");
        rvd.Remove("LinkName");
        return helper.ActionLink(request.LinkName, request.ActionName, request.ControllerName, rvd, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
    }
