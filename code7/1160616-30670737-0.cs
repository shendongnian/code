    kernel.Bind<IFoo>().ToMethod(
        kernel => {
            Tracker.FooIsInitialized = true;
            return new MyFoo(kernel.Get<IDependency>());
        })
        .InSingletonScope()
        .WithConstructorArgument("bar", new Action<IFoo>(foo =>
        {
            // some function here
        }));
