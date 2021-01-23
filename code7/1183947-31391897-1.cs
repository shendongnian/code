    IUnityContainer container = new UnityContainer();
    // Register all IQuery's
    container.RegisterType<IActiveUsersQuery, ActiveUsersQuery>();
    container.RegisterType<IUserByEmailQuery, UserByEmailQuery>();
    IDictionary<Type, Func<IQuery>> factoryQueries = new Dictionary<Type, Func<IQuery>>()
    {
        { typeof(IActiveUsersQuery), () => container.Resolve<IActiveUsersQuery>() },
        { typeof(IUserByEmailQuery), () => container.Resolve<IUserByEmailQuery>() },
    };
    // Register mapping
    container.RegisterInstance<IDictionary<Type, Func<IQuery>>>(factoryQueries);
    container.RegisterType<IQueryFactory, QueryFactory>();
    var factory = container.Resolve<IQueryFactory>();
    factory.ResolveQuery<IActiveUsersQuery>().Execute();
    factory.ResolveQuery<IActiveUsersQuery>().Execute();
