    public class WebApiDependencyResolver : IDependencyResolver
    	{
    		protected IUnityContainer container;
    
    		public WebApiDependencyResolver(IUnityContainer container)
    		{
    			if (container == null)
    			{
    				throw new ArgumentNullException("container");
    			}
    			this.container = container;
    		}
    
    		public object GetService(Type serviceType)
    		{
    			try
    			{
    				return container.Resolve(serviceType);
    			}
    			catch (ResolutionFailedException)
    			{
    				return null;
    			}
    		}
    
    		public IEnumerable<object> GetServices(Type serviceType)
    		{
    			try
    			{
    				return container.ResolveAll(serviceType);
    			}
    			catch (ResolutionFailedException)
    			{
    				return new List<object>();
    			}
    		}
    
    		public IDependencyScope BeginScope()
    		{
    			var child = container.CreateChildContainer();
    			return new WebApiDependencyResolver(child);
    		}
    
    		public void Dispose()
    		{
    			container.Dispose();
    		}
    	}
