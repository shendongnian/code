    var routeData = filterContext.RouteData;
    
    var routeValueDictionary =
        new RouteValueDictionary(
            new
            {
                culture = code,
                controller = routeData.Values["controller"],
                action = routeData.Values["action"],
                id = routeData.Values["id"],
            });
    
    var queryString = filterContext.HttpContext.Request.QueryString;
    foreach (var key in queryString.AllKeys)
    {
        routeValueDictionary.Add(key, queryString[key]);
    }
    
    filterContext.Result = new RedirectToRouteResult(routeValueDictionary);
