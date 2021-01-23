    container.RegisterWithContext<IApplicationDatabaseFactory>(context =>
    {
        Type commandType = context.ServiceType.GetGenericArguments().Single();
        if (commandType == typeof(AddEntityCommand))
        {
            return container.GetInstance<IAuthorizationDatabaseFactory>();
        }
        else
        {
            throw new InvalidOperationException();
        }
    });
