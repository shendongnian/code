    IUnityContainer container = new UnityContainer();
    container.RegisterType<ISettings, Settings1>("settings1");
    container.RegisterType<ISettings, Settings2>("settings2");
    container.RegisterType<IRepository, Repository1>("repository1");
    container.RegisterType<IRepository, Repository2>("repository2");
    container.RegisterType<IBusinessLogic, BusinessLogic1>("logic1");
    container.RegisterType<IBusinessLogic, BusinessLogic2>("logic2");
    string inputParam1 = "logic1";
    string inputParam2 = "settings1";
    string inputParam3 = "repository1";
    var result = container.Resolve<IBusinessLogic>(inputParam1,
        new DependencyOverride<ISettings>(new ResolvedParameter<ISettings>(inputParam2)),
        new DependencyOverride<IRepository>(new ResolvedParameter<IRepository>(inputParam3)));
