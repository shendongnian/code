    ContainerBuilder builder = new ContainerBuilder();
    builder.RegisterType<Foo>().AsSelf();
    builder.RegisterType<FooFactory>().AsSelf().SingleInstance();
    builder.Register(c => new Func<Int32, Foo>(c.Resolve<FooFactory>().GetInstance))
           .As<Func<Int32, Foo>>()
           .SingleInstance();
