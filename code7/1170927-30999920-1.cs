    ContainerBuilder builder = new ContainerBuilder();
    builder.RegisterType<Foo>().As<A.IFoo>();
    builder.RegisterType<Bar>().As<B.IBar>();
    builder.RegisterGeneric(typeof(Adapter1<>)).As(typeof(IAdapter<>));
    builder.RegisterGeneric(typeof(Adapter2<>)).As(typeof(IAdapter<>));
    IContainer container = builder.Build();
    var fooAdapter = container.Resolve<IAdapter<A.IFoo>>(); // should return Adapter1<Foo>()
    var barAdapter = container.Resolve<IAdapter<B.IBar>>(); // should return Adapter2<Bar>()
