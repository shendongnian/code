    [assembly: OwinStartup(typeof(Bla.Startup))]
    namespace Bla
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                //...  
                var container = new WindsorContainer().Install(new ControllerInstaller());
    	    var httpDependencyResolver = new WindsorHttpDependencyResolver(container);
                config.DependencyResolver = httpDependencyResolver;
                //...
            }
    }
    
    public class ControllerInstaller : IWindsorInstaller
    {
    	public void Install(IWindsorContainer container, IConfigurationStore store)
    	{
    	    container.Register(AllTypes.FromThisAssembly()
    		.Pick().If(t => t.Name.EndsWith("Controller"))
    		.Configure(configurer => configurer.Named(configurer.Implementation.Name))
    		.LifestylePerWebRequest());
    
    	    //...
    	}
    }
    
    internal class WindsorDependencyScope : IDependencyScope
    {
    	private readonly IWindsorContainer _container;
    	private readonly IDisposable _scope;
    
    	public WindsorDependencyScope(IWindsorContainer container)
    	{
    	    if (container == null)
    	    {
    		throw new ArgumentNullException("container");
    	    }
    
    	    _container = container;
    	    _scope = container.BeginScope();
    	}
    
    	public object GetService(Type t)
    	{
    	    return _container.Kernel.HasComponent(t)
    		? _container.Resolve(t) : null;
    	}
    
    	public IEnumerable<object> GetServices(Type t)
    	{
    	    return _container.ResolveAll(t)
    		.Cast<object>().ToArray();
    	}
    
    	public void Dispose()
    	{
    	    _scope.Dispose();
    	}
    }
    
    internal sealed class WindsorHttpDependencyResolver : IDependencyResolver
    {
    	private readonly IWindsorContainer _container;
    
    	public WindsorHttpDependencyResolver(IWindsorContainer container)
    	{
    	    if (container == null)
    	    {
    		throw new ArgumentNullException("container");
    	    }
    
    	    _container = container;
    	}
    
    	public object GetService(Type t)
    	{
    	    return _container.Kernel.HasComponent(t)
    		 ? _container.Resolve(t) : null;
    	}
    
    	public IEnumerable<object> GetServices(Type t)
    	{
    	    return _container.ResolveAll(t)
    		.Cast<object>().ToArray();
    	}
    
    	public IDependencyScope BeginScope()
    	{
    	    return new WindsorDependencyScope(_container);
    	}
    
    	public void Dispose()
    	{
    	}
    }
