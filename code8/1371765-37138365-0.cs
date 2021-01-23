    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        Func<Type, bool> genericFilter = x => typeof(IEnumerable).IsAssignableFrom(x) && x.GenericTypeArguments.Length == 1;
        var tablesTypes = GetType().GetProperties().Where(x => genericFilter(x.PropertyType)).Select(x => x.PropertyType.GenericTypeArguments.First());
        var toIgnore = new List<Type>();
        foreach (var type in tablesTypes)                
            foreach (var propType in type.GetProperties().Select(x => genericFilter(x.PropertyType) ? x.PropertyType.GenericTypeArguments.First() : x.PropertyType).ToList())
                if (!tablesTypes.Contains(propType))
                    toIgnore.Add(propType);
        modelBuilder.Ignore(toIgnore);
    }
