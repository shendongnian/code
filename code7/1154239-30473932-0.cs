    kernel.Bind(x => x.FromThisAssembly()
        .SelectAllClasses()
        .InheritedFrom(typeof(IRepository<>))
        .BindSelection(this.SelectDefaultInterfaceAndRepositoryBaseInterface));
    private IEnumerable<Type> SelectDefaultInterfaceAndRepositoryBaseInterface(
        Type t,
        IEnumerable<Type> baseTypes)
    {
        yield return baseTypes.Single(x => 
                                       x.IsGenericType
                                       && x.GetGenericTypeDefinition() == typeof(IRepository<>));
        yield return typeof(IRepository<EntityBase>);
    }
