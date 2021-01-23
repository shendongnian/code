    var container = new Container();
    container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
    container.Register<IMemberRepository, MemberRepository>(Lifestyle.Scoped);
    container.Register<IMemberService, MemberService>(Lifestyle.Scoped);
    container.Register<DbContext, MemberContext>(Lifestyle.Scoped);
    container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
