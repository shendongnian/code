    // `items` is the list containing the two RibbonButtonAggregateViewModels
    var correctItems = items.Where(x =>
    {
        if (!x.GetType().IsGenericType) return false;
        var baseType = x.GetType().BaseType;
        if (baseType == null || !baseType.IsGenericType) return false;
        return baseType.GetGenericTypeDefinition() == typeof (RibbonButtonViewModel<>);
    })
    .ToList<dynamic>();
    correctItems[0].KeyTip = ""; // will compile but fail at runtime if the type doesn't has such a property.
