    if (dict1[entry.Key].GetType().IsGenericType)
    {
       var typeArguments = t.GetGenericArguments();
       //if you only have List<T> in there, you can pull the first one
       var listType = typeArguments[0];
       if (listType.IsEnum) {
            // List elements matches...
       }                
    } 
