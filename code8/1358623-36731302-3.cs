    public async Task RouteAsync(RouteContext context)
    {
        var requestPath = context.HttpContext.Request.Path.Value;
        if (!string.IsNullOrEmpty(requestPath) && requestPath[0] == '/')
        {
            // Trim the leading slash
            requestPath = requestPath.Substring(1);
        }
		
		var segments = requestPath.Split('/');
		// Required: Match condition to determine if the incoming request
		// matches this route. If not, you should allow the framework to
		// match another route by doing nothing here.
        if (segments.Length > 0 && segments[0].Equals("libraryname", StringComparison.OrdinalIgnoreCase))
        {
			var oldRouteData = context.RouteData;
			var newRouteData = new RouteData(oldRouteData);
			newRouteData.Values["library"] = segments[0];
			newRouteData.Values["controller"] = segments[1];
			newRouteData.Values["action"] = segments[2];
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
    }
