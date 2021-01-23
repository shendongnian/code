    container.RegisterWithContext<IApplicationDatabaseFactory>(context =>
    {
        if (typeof(IAuthorizationDatabaseFactory)
            .IsAssignableFrom(context.ImplementationType))
        {
            return container.GetInstance<IAuthorizationDatabaseFactory>();
        }
        else if (typeof(ISWTDatabaseFactory)
            .IsAssignableFrom(context.ImplementationType))
        {
            return container.GetInstance<ISWTDatabaseFactory>();
        }
        else
        {
            throw new InvalidOperationException();
        }
    }); 
