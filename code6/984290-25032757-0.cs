    public object Get()
    {
        var properties =
            typeof (TEntity).GetProperties()
                .Where(m => m.PropertyType.IsGenericType && 
                        m.PropertyType.GetGenericTypeDefinition() == typeof (ICollection<>));
    }
