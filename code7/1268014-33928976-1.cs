    var classNames = typeof(MyDbContext)
        .GetProperties()
        .Where(prop => prop.PropertyType.IsGenericType && 
                       prop.PropertyType.GetGenericTypeDefinition() == typeof(IDbSet<>))
        .Where(x => x.PropertyType.GenericTypeArguments.Count() > 0)
        .Select(x => x.PropertyType.GenericTypeArguments
                      .First()
                      .AssemblyQualifiedName)
        .Distinct();
    
    foreach (var className in classNames)
    {
        var type = Type.GetType(className);
    }
