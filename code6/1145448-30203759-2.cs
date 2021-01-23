    ContainerBuilder builder = new ContainerBuilder();
    builder.RegisterModule(new RestrictingRegistrationModule());
    builder.RegisterType<Bar>().As<Bar>();
    builder.RegisterType<Bar2>().As<Bar2>();
    builder.RegisterType<Foo>().As<IFoo>().OnlyForInheritorsOf(typeof(Bar));
    IContainer container = builder.Build();
    Bar bar = container.Resolve<Bar>();
    Bar2 bar2 = container.Resolve<Bar2>(); // will throw
