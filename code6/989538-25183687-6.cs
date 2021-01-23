    bool IsOf_OrMoreDerived<T>(object instance)
    {
        if (instance == null)
            throw new ArgnumentNullException();
        
        return typeof(T).IsAssignableFrom(instance.GetType());
    }
