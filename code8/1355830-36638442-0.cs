    public IEnumerable<Type> GetTypes<TAssignableFrom>()
    {
        return this.GetType().Assembly.GetTypes()
            .Where(type => type.IsAssignableFrom(typeof (TAssignableFrom)));
    }
