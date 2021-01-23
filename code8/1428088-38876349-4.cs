    TInterface Instantiate<TEntity, TInterface>()
            where TEntity : class, TInterface
            where TInterface : class
    {
        return (TInterface)Activator.CreateInstance(Type.GetType("Namespace" + typeof(TEntity).FullName.Replace("Bo", "")));
    }
