	// Must be singleton
	builder.Register<SingletonDataService>().As(IDataService).SingleInstance();
	builder.RegisterGeneric(typeof(Repository<>))
		   .As(typeof(IRepository<>))
		   .InstancePerLifetimeScope();
	builder.Register<EFUnitOfWork>().As(IEFUnitOfWork).InstancePerLifetimeScope();
	builder.Register<DbContext>().As(AppDbContext).InstancePerLifetimeScope();
