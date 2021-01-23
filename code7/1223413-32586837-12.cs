	namespace Microsoft.AspNet.Routing
	{
		public interface IRouter
		{
            // Derives a virtual path (URL) from a list of route values
			VirtualPathData GetVirtualPath(VirtualPathContext context);
            // Populates route data (including route values) based on the
            // request
			Task RouteAsync(RouteContext context);
		}
	}
