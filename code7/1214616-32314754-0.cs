    public IEnumerable<IEnumerable<IStuff>> GetStuffCollections()
    {
        var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            Type pt = property.PropertyType;
            if (pt.IsGenericType
                && pt.GetGenericTypeDefinition() == typeof(ICollection<>)
                && typeof(IStuff).IsAssignableFrom(pt.GetGenericArguments()[0]))
            {
                yield return (IEnumerable<IStuff>)property.GetValue(this);
            }
        }
    }
