    var objectContext = (context as IObjectContextAdapter).ObjectContext;
    var entitySet = objectContext.CreateObjectSet<YOUR_ENTITY>().EntitySet;
    var keys = entitySet.ElementType.KeyMembers.Select(k =>
    {
        var type = GetTypedEdmValue(k.TypeUsage.EdmType);                    
        return new
        {
            KeyName = k.Name,
            KeyType = type,
            KeyDefaultValue = GetDefaultValue(type)
    
        };
    }).ToList();
