    var assemblies = BuildManager.GetReferencedAssemblies();
    container.RegisterAssemblyTypes(assemblies)
             .Where(t => t.Name.EndsWith("Service"))
             .SingleInstance()
             .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
