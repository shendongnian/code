	Container = new WindsorContainer();
	Container.Kernel.Resolver.AddSubResolver(new CollectionResolver(Container.Kernel));
	// Interceptor
	Container.Register(Component.For<IInterceptor>().ImplementedBy<SomeInterceptor>().LifestyleTransient());
	
	// Component registrations
	RegisterComponent<ISomeService, SomeService>();
	
	
