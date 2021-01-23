    public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
    {
        var currentController = htmlHelper.ViewContext.ParentActionViewContext.RouteData.GetRequiredString("controller");
        var currentUrl = HttpContext.Current.Request.Url.AbsolutePath.TrimStart('/').Split('/');
        var mainCategory = currentUrl[0];
            
        var builder = new TagBuilder("li")
        {
            InnerHtml = htmlHelper.ActionLink(linkText, actionName, controllerName).ToHtmlString()
        };
        builder.AddCssClass("dropdown");
        var actionSplit = actionName.TrimStart('/').Split('/');
        actionName = actionSplit[0];
        if (actionSplit.Length == 1)
        {
            if (controllerName == currentController && actionName == mainCategory)
            {
                return new MvcHtmlString(builder.ToString().Replace("a href", "a class=\"active\" href").Replace("</li>", "").Replace("Home/", ""));
            }
        }
        return new MvcHtmlString(builder.ToString().Replace("</li>", "").Replace("Home/", ""));
    }
