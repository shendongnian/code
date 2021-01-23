    public class SomeExecutor
    {
    	private readonly ILifetimeScope _scope;
    
    	public SomeExecutor(ILifetimeScope scope)
    	{
    		_scope = scope;
    	}
    
    	public async Task RunAsync<T>() where T:ISomeInterface
    	{
    		var tt = _scope.Resolve<T>(); 
    		await  tt.SomeTask();
    	}
    }
    static void Main(string[] args)
    {
    		var builder = new ContainerBuilder();
    		builder.RegisterType<SomeExecutor>();
    		builder.RegisterAssemblyTypes(typeof(ISomeInterface).Assembly)
    			.Where(x => typeof(ISomeInterface).IsAssignableFrom(x))
    			.AsImplementedInterfaces()
    			.AsSelf();
    		var container = builder.Build();
    		var executor = container.Resolve<SomeExecutor>();
    		executor.RunAsync<TypeA>().Wait();
    	}
