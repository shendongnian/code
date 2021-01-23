	public class DbDrivenRouter : IRouter
	{
		// TODO: Make the list thread safe, 
		// provide a way to populate it, and provide caching
		private List<IRouter> routers;
		
		public VirtualPathData GetVirtualPath(VirtualPathContext context)
		{
			foreach (var router in this.routers)
			{
				var virtualPathData = router.GetVirtualPath(context);
				if (context.IsBound)
				{
					return virtualPathData;
				}
			}
		}
		
		public Task RouteAsync(RouteContext context)
		{
			// TODO: Work out a way to run these 
			// simultaneously - this is pseudo code
			foreach (var router in this.routers)
			{
				var task = router.RouteAsync(context);
				if (context.IsHandled)
				{
					return task;
				}
			}
		}
	}
