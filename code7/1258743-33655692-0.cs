    // register another cache
    container.Register(Component.For<ICache>()
                                .ImplementedBy<DummyCache>()
                                .LifeStyle.Singleton
                                .Named("otherCache"));
    container.Register(Component.For<IRepository>()
                                .ImplementedBy<CoolRepository>()
                                .LifeStyle.Singleton
                                .Named("repo")
                                .DependsOn(Dependency.OnComponent("first", "dbcache"))
                                .DependsOn(Dependency.OnComponent("second", "otherCache")));
