	container.RegisterType<IRepository<MyType>, XRepository>(new HierarchicalLifetimeManager());
	container.RegisterType<IXRepository, XRepository>();
	
	var first = container.Resolve<IRepository<MyType>>();
	var second = container.Resolve<IXRepository>();
	
	Console.WriteLine("Same instance: {0}", ReferenceEquals(first, second));
