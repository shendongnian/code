    public async Task RouteAsync(RouteContext context)
    {
		// Request path is the entire path (without the query string)
		// starting with a forward slash.
		// Example: /Home/About
        var requestPath = context.HttpContext.Request.Path.Value;
		if (!requestPath == <some comparison (slice the string up if you need to)>)
		{
			// Condition didn't match, returning here will
            // tell the framework this route doesn't match and
            // it will automatically call the next route.
            // This is similar to returning "false" from a route constraint.
			return;
		}
        
        // Invoke MVC controller/action.
        // We use a copy of the route data so we can revert back
        // to the original.
        var oldRouteData = context.RouteData;
        var newRouteData = new RouteData(oldRouteData);
        newRouteData.Routers.Add(_target);
        // TODO: Set this in the constructor or based on a data structure.
        newRouteData.Values["controller"] = "Custom"; 
        newRouteData.Values["action"] = "Details";
        // Set any other route values here (such as "id")
        try
        {
            context.RouteData = newRouteData;
			
			// Here we are calling the nested route asynchronously.
            // The nested route should generally be an instance of
            // MvcRouteHandler.
            // Calling it is similar to returning "true" from a
            // route constraint.            
            await _target.RouteAsync(context);
        }
        finally
        {
            // Restore the original values to prevent polluting the route data.
            if (!context.IsHandled)
            {
                context.RouteData = oldRouteData;
            }
        }
    }
