    var builder = new ContainerBuilder();
    builder.RegisterType<MyDbContext>()
           .As<IDataContextAsync>()
           .InstancePerRequest();
    builder.RegisterType<UnitOfWork>()
           .As<IUnitOfWorkAsync>()
           .InstancePerRequest();
    builder.RegisterGeneric(typeof(Repository<>))
           .As(typeof(IRepositoryAsync<>))
           .InstancePerRequest();
    builder.RegisterAssemblyTypes(typeof(AccountService).Assembly)
           .Where(t => t.Name.EndsWith("Service"))
           .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name))
           .InstancePerRequest();
    Container = builder.Build();
