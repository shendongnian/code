    public async Task RouteAsync(RouteContext context)
    {
        var oldRouteData = context.RouteData;
        var newRouteData = new RouteData(oldRouteData);
        newRouteData.Values["library"] = "Default";
        newRouteData.Values["controller"] = "Home";
        newRouteData.Values["action"] = "About";
        try
        {
            context.RouteData = newRouteData;
            await _defaultRouter.RouteAsync(context);
        }
        finally
        {
            if (!context.IsHandled)
            {
                context.RouteData = oldRouteData;
            }
        }
    }
