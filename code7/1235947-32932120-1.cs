	container.RegisterType<CurrentRequest>(
				new HierarchicalLifetimeManager());
	container.RegisterType<IOwinContext>(
		new HierarchicalLifetimeManager(),
		new InjectionFactory(c => c.Resolve<CurrentRequest>().Value.GetOwinContext()));
	httpConfiguration.DependencyResolver = new UnityHierarchicalDependencyResolver(container);
