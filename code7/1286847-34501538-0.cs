    var builder = new ContainerBuilder();
    builder.RegisterType<CacheRepository>().As<ICacheRepository>();
    builder.Register(c => new CacheHelper(c.Resolve<ICacheRepository>()))
           .As<CacheHelper>()
           .SingleInstance();
