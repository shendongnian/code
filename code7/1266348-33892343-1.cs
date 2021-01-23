    var container = new WindsorContainer();
    container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
    container.Register(
        Component.For<IOrderRepository>().ImplementedBy<CacheOrderRepo>(),
        Component.For<IOrderRepository>().ImplementedBy<RealTimeRepo1>(),
        Component.For<IOrderRepository>().ImplementedBy<RealTimeRepo2>(),
        Component.For<LocalOrderRepo>().ImplementedBy<LocalOrderRepo>());
    var service = container.Resolve<IOrderRepository>();
    Assert.IsInstanceOf<CacheOrderRepo>(service);
