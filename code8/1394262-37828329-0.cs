    var kernel = new StandardKernel();
    kernel.Bind<IB>().To<B>()
        .WithParameter(
            new TypeMatchingConstructorArgument(
                typeof(IC), 
                (ctx, target) => ctx.Kernel.Get<C1>()));
    kernel.Bind<IB>().To<B>()
        .WithParameter(
            new TypeMatchingConstructorArgument(
                typeof(IC),
                (ctx, target) => ctx.Kernel.Get<C2>()));
    kernel.Bind<IA>().To<A>();
    var a = kernel.Get<IA>();
