	// Begin composition root
	var container = new UnityContainer();
	container.RegisterType<ITypeA, TypeA>();
	container.RegisterType<ITypeB, TypeB>();
	// End composition root
	var typeA = container.Resolve<ITypeA>();
	var typeB = container.Resolve<ITypeB>();
