     public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<DbContext, DBContext1>(new PerThreadLifetimeManager());
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IRepository<Photo>, Repository<Photo>>(new PerThreadLifetimeManager(),new InjectionConstructor(new DBContext2()));
			....
			container.RegisterType<IGenderService, GenderService>();
			container.RegisterType<ILanguageService, LanguageService>();
			....
			container.RegisterType<IPhotoService, PhotoService>();
			}
