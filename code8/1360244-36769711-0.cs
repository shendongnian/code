    void Main()
    {
    	var builder = new ContainerBuilder();
    
    	builder.Register<Component>(c=>new Component(123));
    
    	IContainer root = builder.Build();
    
    	using (ILifetimeScope lf = root.BeginLifetimeScope())
    	{
    		var comp = lf.Resolve<Component>();		
    	}
    }
    
    class Component : IDisposable
    {
    	public Component(int i) { }
    
    	public void Dispose()
    	{
    		throw new NotImplementedException();
    	}
    }
