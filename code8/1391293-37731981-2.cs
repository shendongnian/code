    public virtual string Action(string actionName, string controllerName, object routeValues)
    {
        return GenerateUrl(null /* routeName */, actionName, controllerName, TypeHelper.ObjectToDictionary(routeValues));
    }
    public virtual string Action(string actionName, string controllerName, RouteValueDictionary routeValues)
    {
        return GenerateUrl(null /* routeName */, actionName, controllerName, routeValues);
    }
    //...other code removed for brevity
        
    public virtual string RouteUrl(string routeName, object routeValues, string protocol)
    {
        return GenerateUrl(routeName, null /* actionName */, null /* controllerName */, protocol, null /* hostName */, null /* fragment */, TypeHelper.ObjectToDictionary(routeValues), RouteCollection, RequestContext, false /* includeImplicitMvcValues */);
    }
