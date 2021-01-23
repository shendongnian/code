    var queryHandlerTypes = container.GetTypesToRegister(typeof(IQueryHandler<,>), 
        settings.QueryHandlerAssemblies,
        new TypesToRegisterOptions { IncludeGenericTypeDefinitions = true });
    container.Register(typeof(IQueryHandler<,>), 
        queryHandlerTypes.Where(t => !t.IsGenericTypeDefinition));
	
	foreach (Type type in queryHandlerTypes.Where(t => t.IsGenericTypeDefinition))
	{
		container.Register(typeof(IQueryHandler<,>), type);
	}
