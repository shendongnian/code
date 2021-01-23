    private static IEnumerable<Type> SelectConsumeInterfacesOnly(
        Type type, IEnumerable<Type> baseTypes)
    {
        var matchingTypes = baseTypes.Where(t => 
             t.IsGenericType
             && t.GetGenericTypeDefinition() == typeof (IConsume<>));
        return matchingTypes;
    }
    kernel.Bind(x => x.FromThisAssembly()
        .IncludingNonePublicTypes()
        .SelectAllClasses()
        .InheritedFrom(typeof(IConsume<>))
        .BindSelection(SelectConsumeInterfacesOnly));
