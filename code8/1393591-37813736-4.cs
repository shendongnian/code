    builder.RegisterType<TestImplementationA>()
            .As<ITestInterface<A>>();
    builder.RegisterType<TestImplementationB>()
            .As<ITestInterface<B>>();
    builder.RegisterGeneric(typeof(SomeClass<>))
           .AsSelf();
