    var iRepoType = typeof(IRepo);
    var repoTypes = Assembly.GetExecutingAssembly().GetTypes()
                                                    .Where(type => type.IsClass && iRepoType.IsAssignableFrom(type))
                                                    .ToList();
    
    foreach(var repoType in repoTypes)
    {
        builder.RegisterType(repoType).Keyed<IRepository>(repoType);
    }
