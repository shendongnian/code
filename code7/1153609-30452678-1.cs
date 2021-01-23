    builder.Register(c => c.ResolveNamed<IEnumerable<Meta<IFoo>>>("Ordered")
                           .OrderBy(metaFoo => (Int32)metaFoo.Metadata["order"])
                           .Select(metaFoo => metaFoo.Value)
                           .First())
           .As<IFoo>();
    // classic registration
    builder.RegisterType<Foo1>()
           .Named<IFoo>("Ordered")
           .WithMetadata("order", 20);
    // this registration can be provided by a RegistrationSource
    builder.RegisterType<Foo2>()
           .Named<IFoo>("Ordered")
           .WithMetadata("order", 10);
