    void Main()
    {
    	IContainer container = new ContainerBuilder().Build();
        ContainerBuilder builder = new ContainerBuilder();
    	
    	builder.RegisterInstance(container).As<IContainer>();
    
    	builder.RegisterType<ManagementServiceImp>().As<IManagmentServiceImp>()
           .WithParameter(new ResolvedParameter(
    			(pi, ctx) => pi.ParameterType == typeof(IContainer) && pi.Name == "Container",
    			(pi, ctx) => container
    	));
    
    	container = builder.Build();
    	var instance = container.Resolve<IManagmentServiceImp>();
    }
    
    public class ManagementServiceImp : IManagmentServiceImp 
    { 
    	private IContainer _container;
    
    	public ManagementServiceImp(IContainer Container)
    	{
    		_container = Container;
    		_container.Dump();
    	}
    }
    
    public interface IManagmentServiceImp { }
