    private static void Register(...)
    {
        foreach (var type in GetInheriteTypes())
        {          
            container.Register(Component.For(typeof(IRepository<>),type)
                                        .ImplementedBy(typeof(SuperRepository<>)));
        }
        container.Register(Component.For(typeof(IRepository<>))
                                    .ImplementedBy(typeof(Repository<>)));
    }
    private static IEnumerable<Type> GetInheriteTypes()
    {
        var listOfBs = (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                        from assemblyType in domainAssembly.GetTypes()
                        where assemblyType.GetInterfaces().Contains(typeof(ISuperType))
                        select assemblyType).ToArray();
        return listOfBs;
    }
