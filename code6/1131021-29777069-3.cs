    public static class WebApiBootstrapper
    	{
    		public static void Init(IUnityContainer container)
    		{
    			GlobalConfiguration.Configure(config =>
    			{
    				config.DependencyResolver = new WebApiDependencyResolver(container); // DI container for use in WebApi
    				config.MapHttpAttributeRoutes();
    				WebApiRouteConfig.RegisterRoutes(RouteTable.Routes);
    			});
    
    			// Web API mappings
    			// All components that implement IDisposable should be 
    			// registered with the HierarchicalLifetimeManager to ensure that they are properly disposed at the end of the request.
    			container.RegisterType<IYourController, YourController>(
    			new HierarchicalLifetimeManager(), new InjectionConstructor(typeof(IMyDataBase)));
    		}
    	}
