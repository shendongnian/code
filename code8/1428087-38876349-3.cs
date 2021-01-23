    Dictionary<Type, Type> _types = new Dictionary<Type, Type>
    {
        { typeof(IEntityA), typeof(ModelA) },
        { typeof(IEntityB), typeof(ModelB) }
    };
    TInterface Instantiate<TInterface>()
            where TInterface : class
    {
        return (TInterface)Activator.CreateInstance(Type.GetType(_types[typeof(TInterface)].FullName.Replace("1", "2")));
    }
