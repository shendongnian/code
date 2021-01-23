    public static MvcHtmlString MenuRouteLink(this HtmlHelper htmlHelper, string linkText, string routeName, RouteValueDictionary routeValues = null, IDictionary<string, object> htmlAttributes = null)
    {
    	var currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
    	var currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
    	if (htmlAttributes == null) htmlAttributes = new Dictionary<string, object>();
    
    	var route = RouteTable.Routes[routeName] as Route;
    	if (route != null)
    	{
    		routeValues = routeValues ?? new RouteValueDictionary();
    		var routeAction = (routeValues["action"] as string ?? route.Defaults["action"] as string) ?? String.Empty;
    		var routeController = (routeValues["controller"] as string ?? route.Defaults["controller"] as string) ?? String.Empty;
    
    		if (routeAction.Equals(currentAction, StringComparison.OrdinalIgnoreCase) && routeController.Equals(currentController, StringComparison.OrdinalIgnoreCase))
    		{
    			var currentCssClass = htmlAttributes.ContainsKey("class") ? htmlAttributes["class"] as string : String.Empty;
    			htmlAttributes["class"] = String.Concat(currentCssClass, !String.IsNullOrEmpty(currentCssClass) ? " " : String.Empty, "selected");
    		}
    	}
    
    	return htmlHelper.RouteLink(linkText, routeName, routeValues, htmlAttributes);
    }
