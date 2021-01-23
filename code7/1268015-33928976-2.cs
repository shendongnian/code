    var classNames = typeof(MyDbContext)
        .GetProperties()
        .Where(prop => prop.PropertyType.IsGenericType && 
                       prop.PropertyType.GetGenericTypeDefinition() == typeof(IDbSet<>))
        .Where(prop => prop.PropertyType.GenericTypeArguments.Count() > 0)
        .Select(prop => prop.PropertyType.GenericTypeArguments
                      .First()
                      .AssemblyQualifiedName)
        .Distinct();
    
    foreach (var className in classNames)
    {
        var type = Type.GetType(className);
    }
