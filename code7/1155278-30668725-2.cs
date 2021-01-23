    internal class Startup
    	{
    		public Func<int, string> Restart;
    
    		public void Configuration(IAppBuilder app)
    		{
    			var resolver = new DefaultDependencyResolver();
    			resolver.Register(typeof(ConfigurationHub), () => new ConfigurationHub(Restart));
    
    			var hubConfiguration = new HubConfiguration
    			{
    				EnableJSONP = true,
    				EnableDetailedErrors = true,
    				Resolver = resolver
    			};
    
    			app.MapSignalR(hubConfiguration);
    		}
    	}
