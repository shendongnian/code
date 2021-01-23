    container.Register<AdministratorUserRepository>();
    container.Register<NormalUserRepository>();
    container.Register<IUserRepository>(() =>
    {
        container.GetInstance<IUserContext>().IsAdministrator
            ? container.GetInstance<AdministratorUserRepository>()
            : container.GetInstance<NormalUserRepository>();
    });
