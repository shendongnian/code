    builder.Register(ctx =>
    {
        IServiceA serviceA = ctx.Resolve<IServiceA>();
        IServiceB serviceB = ctx.Resolve<IServiceB>(TypedParameter.From(serviceA));
        IServiceC serviceC = ctx.Resolve<IServiceC>(TypedParameter.From(serviceA));
        IServiceD serviceD = ctx.Resolve<IServiceD>(TypedParameter.From(serviceA), TypedParameter.From(serviceB), TypedParameter.From(serviceC));
        return serviceD;
    }).As<IServiceD>();
