    container.Register(Types.FromThisAssembly()
        .BasedOn<IService>()
        .Configure(c =>
            c.UsingFactoryMethod((k, ctx) => GetService(ctx.RequestedType))
        )
    );
