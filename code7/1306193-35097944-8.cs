	public class MyRoute : IRouter
	{
        private readonly IRouter innerRouter;
        public MyRoute(IRouter innerRouter)
        {
            if (innerRouter == null)
                throw new ArgumentNullException("innerRouter");
            this.innerRouter = innerRouter;
        }
		public async Task RouteAsync(RouteContext context)
		{
			var requestPath = context.HttpContext.Request.Path.Value;
			if (!string.IsNullOrEmpty(requestPath) && requestPath[0] == '/')
			{
				// Trim the leading slash
				requestPath = requestPath.Substring(1);
			}
			if (!requestPath.StartsWith("abcd"))
			{
				return;
			}
			
			//Invoke MVC controller/action
			var oldRouteData = context.RouteData;
			var newRouteData = new RouteData(oldRouteData);
			newRouteData.Routers.Add(this.innerRouter);
			newRouteData.Values["controller"] = "Item";
			newRouteData.Values["action"] = "View";
			newRouteData.Values["id"] = 123;
			try
			{
				context.RouteData = newRouteData;
				await this.innerRouter.RouteAsync(context);
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
		
		public VirtualPathData GetVirtualPath(VirtualPathContext context)
		{
			VirtualPathData result = null;
			var values = context.Values;
			var controller = Convert.ToString(values["controller"]);
			var action = Convert.ToString(values["action"]);
			var id = Convert.ToString(values["id"]);
			
			if ("Item".Equals(controller) && "View".Equals(action))
			{
                result = new VirtualPathData(this, "abcd?id=" + id);
                context.IsBound = true;
			}
			// IMPORTANT: Always return null if there is no match.
			// This tells .NET routing to check the next route that is registered.
			return result;
		}
	}
