    public async Task RouteAsync(RouteContext context)
    {
        var requestPath = context.HttpContext.Request.Path.Value;
        if (!string.IsNullOrEmpty(requestPath) && requestPath[0] == '/')
        {
            // Trim the leading slash
            requestPath = requestPath.Substring(1);
        }
        // Get the page that matches.
        var page = GetPageList()
            .Where(x => x.VirtualPath.Equals(requestPath))
            .FirstOrDefault();
        // If we got back a null value set, that means the URI did not match
        if (page == null)
        {
            return;
        }
        //Invoke MVC controller/action
        var oldRouteData = context.RouteData;
        var newRouteData = new RouteData(oldRouteData);
        newRouteData.Routers.Add(this.target);
        // TODO: You might want to use the page object (from the database) to
        // get both the controller and action, and possibly even an area.
        // Alternatively, you could create a route for each table and hard-code
        // this information.
        newRouteData.Values["controller"] = "Custom";
        newRouteData.Values["action"] = "Details";
        // This will be the primary key of the database row.
        // It might be an integer or a GUID.
        newRouteData.Values["id"] = page.Id;
        context.RouteData = newRouteData;
        try
        {
            context.RouteData = newRouteData;
            await this.target.RouteAsync(context);
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
