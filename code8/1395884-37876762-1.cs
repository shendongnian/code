    builder.RegisterType<Foo>()
           .As<IFoo>();
    builder.RegisterType<FooFactory>()
           .As<IFooFactory>()
           .SingleInstance();
    builder.Register<Func<String, IFoo>>(c => c.Resolve<IFooFactory>().Get)
           .As<Func<String, IFoo>>();
