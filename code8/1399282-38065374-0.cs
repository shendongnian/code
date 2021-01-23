    public LandingPageRouter(IRouteBuilder routeBuilder)
    {
        _routeBuilder = routeBuilder;
    }
    
    public Task RouteAsync(RouteContext context)
    {
        var requestPath = context.HttpContext.Request.Path.Value;
        if (!string.IsNullOrEmpty(requestPath) && requestPath[0] == '/')
        {
            requestPath = requestPath.Substring(1);
        }
    
        var pagefound = GetPages().SingleOrDefault(x => x.Name == requestPath);
        if (pagefound!=null)
        {
            //TODO: Handle querystrings
            var routeData = new RouteData();
            routeData.Values["controller"] = "LandingPage";
            routeData.Values["action"] = "Index";
            routeData.Values["id"] = pagefound.Id;
               
            context.RouteData = routeData;
            return _routeBuilder.DefaultHandler.RouteAsync(context);
        }
        return Task.FromResult(0);
    }
