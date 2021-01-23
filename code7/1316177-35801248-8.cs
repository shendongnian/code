    private object[] ResolveConstructorParameters<TType>()
    {
        return typeof(TType).GetConstructors()
                            .Single(c => c.IsPublic)
                            .GetParameters()
                            .Select(p => _container.Resolve(p.ParameterType))
                            .ToArray();
    }
    
