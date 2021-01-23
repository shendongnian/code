    var builder = new ContainerBuilder();
    builder.RegisterType<MyDbContext>()
           .As<IDataContextAsync>()
           .InstancePerLifetimeScope();
    builder.RegisterType<UnitOfWork>()
           .As<IUnitOfWorkAsync>()
           .InstancePerLifetimeScope();
    builder.RegisterGeneric(typeof(Repository<>))
           .As(typeof(IRepositoryAsync<>))
           .InstancePerLifetimeScope();
    builder.RegisterAssemblyTypes(typeof(AccountService).Assembly)
           .Where(t => t.Name.EndsWith("Service"))
           .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name))
           .InstancePerLifetimeScope();
    Container = builder.Build();
