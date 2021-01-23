    kernel.Bind<string>().ToConstant("hello");
    kernel.Bind<ISingletonDependency>().To<SingletonDependency>()
        .InSingletonScope();
    kernel.DefineDependency<string, ISingletonDependency>();
    kernel.Get<string>();
    // when asking for a string for a first time
    // ISingletonDependency will be instantiated.
    // of course you can use any other type instead of string
