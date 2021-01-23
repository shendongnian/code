	container.RegisterWithContext<IApplicationDatabaseFactory>(context =>
	{
		Type commandType = context.ServiceType.GetGenericArguments().Single();
		if (context.ImplementationType == typeof(IAuthorizationDatabaseFactory))
		{
			return container.GetInstance<IAuthorizationDatabaseFactory>();
		}
		else if (context.ImplementationType == typeof(ISWTDatabaseFactory))
		{
			return container.GetInstance<ISWTDatabaseFactory>();
		}
		else
		{
		    // see here
			return null;
		}
	}); 
