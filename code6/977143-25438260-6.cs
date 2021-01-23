	public class Bootstrapper
	{
		//...
		
		// Create a new caching handler and register it with the container.
		public void RegisterCache(HttpConfiguration config, IUnityContainer container)
		{
			var cachingHandler = new CachingHandler(config);
			// ...
			
			container.RegisterInstance<ICachingHandler>(cachingHandler);
		}
	}
    
	public class ResourceContoller : ApiController
	{
        private ICachingHandler _cachingHandler;
		public ResourceContoller(ICachingHandler cachingHandler)
		{
			_cachingHandler = cachingHandler;		
		}
		
		[HttpPost]
		public void DeleteResource(int resourceId)
		{
			// Do the delete
			// ...
			
			// Now invalidate the related resource cache entry		
			// Construct a http request message to the related resource
            // HINT: The "DefaultApi" may not be your api route name, so change this to match your route.
            // GOTCHA: The route matching mechanism is case sensitive, so be aware!
			var relatedResource = new HttpRequestMessage(HttpMethod.Get, Url.Link("DefaultApi", new {controller = "linkedresource", action = "getlinkedresource", id: resourceId}));
			
			// Invalidate the resource with the caching handler.
			_cachingHandler.InvalidateResource(relatedResource);
		}
	}
