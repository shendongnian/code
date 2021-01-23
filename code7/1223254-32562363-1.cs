    container.RegisterType<IServiceDependancy, ProductionServiceDependancy>("Production");
    container.RegisterType<IServiceDependancy, TestServiceDependancy>("Test");
    container.Register<IServiceDependency>(new InjectionFactory(c =>
        new ServiceDependencySelectionProxy(
            () => IsApplicationTestSwitchEnabled(),
            container.Resolve<IServiceDependency>("Test"),
            container.Resolve<IServiceDependency>("Production"))));
