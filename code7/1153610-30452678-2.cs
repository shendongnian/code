    builder.RegisterType<Foo1>().As<IFoo>().WithMetadata("order", 10);
    builder.RegisterType<Foo2>().As<IFoo>().WithMetadata("order", 20);
    builder.RegisterType<Foo3>().As<IFoo>().WithMetadata("order", 15);
    // ...
    IEnumerable<IFoo> foos = container.Resolve<IEnumerable<Meta<IFoo>>>()
                                        .OrderBy(o => (Int32)o.Metadata["order"])
                                        .Select(o => o.Value);
    // foos => Foo1, Foo3, Foo2
