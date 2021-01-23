    var entry = new TranslationEntry(sourceType, destinationType);
    var propertyInfo = mapping.SourceMember as PropertyInfo;
    if (propertyInfo == null && mapping.ValueResolverConfig != null)
    {
        entry.Resolver = mapping.ValueResolverConfig.Type;
        var expression = mapping.ValueResolverConfig.SourceMember.Body as MemberExpression;
    
        if (expression != null)
            propertyInfo = expression.Member as PropertyInfo;
    }
    
    if (propertyInfo == null)
        return;
    
    entry.DestinationProperty = mapping.DestinationProperty.Name;
    entry.DestinationPropertyType = mapping.DestinationPropertyType;
    entry.SourceProperty = propertyInfo.Name;
    entry.SourcePropertyType = propertyInfo.PropertyType;
