    public static void RegisterComponents()
    {
    var container = new UnityContainer();
    container.RegisterType<DbContext, DBContext1>("Instance 1", new ContainerControlledLifetimeManager());
	DBContext1 instance1 = container.Resolve<DBContext1>("Instance 1");
    container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
    container.RegisterType<DbContext, DBContext2>("Instance 2", new ContainerControlledLifetimeManager());
	DBContext1 instance2 = container.Resolve<DBContext2>("Instance 2");
    container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
    container.RegisterType<IUnitOfWork, UnitOfWork>();
    ......
    container.RegisterType<IGenderService, GenderService>();
    container.RegisterType<ILanguageService, LanguageService>();
    .......
     container.RegisterType<IPhotoService, PhotoService>();
    }
