    var type = typeof(RoutesDemo);
    var attribute = type.GetTypeInfo().GetCustomAttribute<RouteAttribute>();
    if (attribute != null)
    {
        // /page/{Id}
        var routeInfo = attribute.Template;
    }
