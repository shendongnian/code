        builder.RegisterType<Foo>()
               .As<IFoo>()
               .InstancePerOwned<IBar>();
        builder.RegisterType<Bar>()
               .As<IBar>()
               .OnActivated(e => e.Context.Resolve<IFoo>());
