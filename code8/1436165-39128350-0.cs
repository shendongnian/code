    private static void ConfigureAutofac(HttpConfiguration config) 
    {
        var builder = new ContainerBuilder();
        //*************//
        //heres what i did
        //*************//
        var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
			
        foreach (var assembly in assemblies)
	    {
            builder.RegisterAssemblyTypes(assembly).AssignableTo<IQueryResult>().AsImplementedInterfaces();
			builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IQuery<>)).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IQueryHandler<,>)).AsImplementedInterfaces();
        } 
        //rest of the code
    }   
