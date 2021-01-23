    public static class LinkExtensions
    {
       public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, null, new RouteValueDictionary(), new RouteValueDictionary());
        }
        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, null, new RouteValueDictionary(routeValues), new RouteValueDictionary());
        }
        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, controllerName, new RouteValueDictionary(), new RouteValueDictionary());
        }
        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, null, routeValues, new RouteValueDictionary());
        }
        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues, object htmlAttributes)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, null, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes));
        }
        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, null, routeValues, htmlAttributes);
        }
        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, controllerName, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes));
        }
       public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
       {
           if (UserInRole())   // your business logic here for role check
           {
              return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes);
           }
                
           return MvcHtmlString.Empty;
       }
    }
    
