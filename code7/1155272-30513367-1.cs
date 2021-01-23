    public void Register<TFrom, TTo>(params Type[] typesToRegister) where TTo : TFrom
    {
        parentContainer.RegisterType<TFrom, TTo>(new HierarchicalLifetimeManager());
    
        foreach (Type type in typesToRegister)
        {
            parentContainer.RegisterType(type, typeof(TTo));
        }
    }
