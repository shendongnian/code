    container.Register<IPurusLotteryDataContextAsync>(new HierarchicalLifetimeManager(),
        new InjectionFactory(c => new PurusLotteryContext(purusLotteryConnectionString)));
    container.Register<IPurusLotteryBackOfficeDataContextAsync>(
        new HierarchicalLifetimeManager(),
        new InjectionFactory(c => new PurusLotteryBackOfficeContext(
            purusLotteryBackOfficeConnectionString)));
        
    container.RegisterType<ILotteryUnitOfWorkAsync, LotteryUnitOfWork>(
        new HierarchicalLifetimeManager());
    container.RegisterType<ILotteryBackOfficeUnitOfWorkAsync, LotteryBackOfficeUnitOfWork>(
        new HierarchicalLifetimeManager());
