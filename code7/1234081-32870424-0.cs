	public static MvcHtmlString ActionLinkByRequest(this HtmlHelper helper, RequestBase request, object htmlAttributes = null)
	{
		// create new value-dictionary to be passed
		var rvd = new RouteValueDictionary();
		// loop through properties of the request
		foreach (var prop in request.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(p => p.CanRead && p.CanWrite))
		{
			// add name/value to route-dictionary
			rvd.Add(prop.Name, prop.GetValue(request));
		}
		// check if area is needed
		if (!rvd.ContainsKey("Area"))
		{
			rvd.Add("Area", request.Area);
		}
		return helper.ActionLink(request.LinkText, request.ActionName, request.ControllerName, rvd, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
	}
