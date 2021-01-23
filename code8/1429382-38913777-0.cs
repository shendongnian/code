    IUserContext userContext = new AspNetUserContext();
    container.RegisterSingleton<IUserContext>(userContext);
    var contextProducer = Lifestyle.Scoped.CreateProducer<DbContext>(
        () => new MyDbContext(userContext),
        container);
    container.RegisterSingleton<Func<DbContext>>(contextProducer.GetInstance);
