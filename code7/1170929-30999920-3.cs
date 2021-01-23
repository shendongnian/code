    ContainerBuilder builder = new ContainerBuilder();
    builder.RegisterType<Foo>().As<A.IFoo>();
    builder.RegisterType<Bar>().As<B.IBar>();
    builder.RegisterSource(new TestRegistrationSource());
    builder.RegisterGeneric(typeof(Adapter1<>)).Named("Namespace.A", typeof(IAdapter<>));
    builder.RegisterGeneric(typeof(Adapter2<>)).Named("Namespace.B", typeof(IAdapter<>));
    IContainer container = builder.Build();
    var fooAdapter = container.Resolve<IAdapter<A.IFoo>>(); // will return Adapter1<Foo>()
    var barAdapter = container.Resolve<IAdapter<B.IBar>>(); // will return Adapter2<Bar>()
