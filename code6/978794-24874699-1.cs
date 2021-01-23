    // Configure Unity as our DI container
    public class UnityConfig
    {
    
    	private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
    	{
    		var container = new UnityContainer();
    		RegisterTypes(container);
    		return container;
    	});
    
    	public static IUnityContainer GetConfiguredContainer()
    	{
    		return Container.Value;
    	}
    
    
    	private static void RegisterTypes(IUnityContainer container)
    	{
    		var twitterService = new TwitterService();
    		container.RegisterInstance(twitterService);
    		
    		/*
    		 * Using RegisterInstance effectively makes a Singleton instance of 
    		 * the object accessible throughout the application.  If you don't need 
    		 * (or want) the class to be shared among all clients, then use 
    		 * container.RegisterType<TwitterService, TwitterService>();
    		 * which will create a new instance for each client (i.e. each time a Hub
    		 * is created, you'll get a brand new TwitterService object)
    		 */
    	}
    }
    
    
    // If you're using ASP.NET, this can be used to set the DependencyResolver for SignalR 
    // so it uses your configured container
    
    [assembly: WebActivatorEx.PreApplicationStartMethod(typeof(UnitySignalRActivator), "Start")]
    [assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(UnitySignalRActivator), "Shutdown")]
    
    public static class UnitySignalRActivator
    {
    	public static void Start() 
    	{
    		var container = UnityConfig.GetConfiguredContainer();
    		GlobalHost.DependencyResolver = new SignalRUnityDependencyResolver(container);
    	}
    
    	public static void Shutdown()
    	{
    		var container = UnityConfig.GetConfiguredContainer();
    		container.Dispose();
    	}
    }
    
    public class SignalRUnityDependencyResolver : DefaultDependencyResolver
    {
    	private readonly IUnityContainer _container;
    
    	public SignalRUnityDependencyResolver(IUnityContainer container)
    	{
    		_container = container;
    	}
    
    	public override object GetService(Type serviceType)
    	{
    		return _container.IsRegistered(serviceType) 
    			? _container.Resolve(serviceType) 
    			: base.GetService(serviceType);
    	}
    
    	public override IEnumerable<object> GetServices(Type serviceType)
    	{
    		return _container.IsRegistered(serviceType) 
    			? _container.ResolveAll(serviceType) 
    			: base.GetServices(serviceType);
    	}
    }
