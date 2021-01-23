    public static class LinkExtensions
    {
       public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
       {
           if (UserInRole())   // your business logic here for role check
           {
              return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes);
           }
                
           return MvcHtmlString.Empty;
       }
    }
    
