    Bind<IUnitOfWork>().To<UnitOfWorkOfDatabaseA>()
        .WhenInjectedInto<IRepository<SomeEntityOfDatabaseA>>();
    Bind<IUnitOfWork>().To<UnitOfWorkOfDatabaseA>()
        .WhenInjectedInto<IRepository<SomeOtherEntityOfDatabaseA>>();
    Bind<IUnitOfWork>().To<UnitOfWorkOfDatabaseB>()
        .WhenInjectedInto<IRepository<SomeEntityOfDatabaseB>>();
