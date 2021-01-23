    public class Service1Factory : DefaultServiceHostFactory
    {
    	public Service1Factory()
    		: base(Service1Factory.CreateKernel())
    	{
    	}
    
    	private static IKernel CreateKernel()
    	{
    		var Container = AppContext.Container; // application container
    		var serviceContainer = new WindsorContainer();
    		serviceContainer.AddFacility<WcfFacility>();
    		serviceContainer.Register(Component.For<IService1>().ImplementedBy<Service1>().LifestyleTransient());
    		serviceContainer.Register(Component.For<IServiceBehavior>().ImplementedBy<SecurityServiceBehavior>().LifestyleTransient());
    		serviceContainer.Register(Component.For<ISecuritySettingsProvider>()
    			.ImplementedBy<Service1SettingsProvider>().LifestyleSingleton());
    		Container.AddChildContainer(serviceContainer);
    		return serviceContainer.Kernel;
    	}
    }
