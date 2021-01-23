    var builder = new ContainerBuilder();
    
    builder.RegisterInstance(config)
        .As<MembershipRebootConfiguration<CustomUserAccount>>();
    builder.RegisterType<CustomRepository>()
        .As<IUserAccountRepository<CustomUserAccount>>()
        .InstancePerRequest();
    builder.RegisterType<CustomDatabase>()
        .AsSelf()
        .InstancePerRequest();
    builder.RegisterType<CustomRepository>()
        .As<IUserAccountQuery>()
        .InstancePerRequest();
    builder.RegisterType<SamAuthenticationService<CustomUserAccount>>()
        .As<AuthenticationService<CustomUserAccount>>();
