    if (type is IEnumerable)
    {
        var listGenericType = type.GetType().GetGenericTypeDefinition();
        if (listGenericType == typeof(List<>)) {
        //do something
        }
        else if (listGenericType == typeof(HashShet<>)) {
        //do something
        }
     } 
