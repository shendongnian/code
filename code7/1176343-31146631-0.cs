    Type propertyType = ((dynamic)linqColumn).PropertyType;
    
    // Visual Studio should now warn you if you try to use:
    // var args = propertyType.GenericTypeArguments;
    
    var args = propertyType.IsGenericType && !propertyType.IsGenericTypeDefinition
        ? propertyType.GetGenericArguments()
        : Type.EmptyTypes;
