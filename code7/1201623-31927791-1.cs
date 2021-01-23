    Bind<IScopeRootFactory>().To<ScopeRootFactory>();
    Bind<IScopeRoot>().To<ScopeRoot>()
        .InNamedScope("ScopeName");
    Bind<IRootedObject>().To<RootedObject>()
         .InNamedScope("ScopeName");
