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
    		}
    	}
