    var listType = dict1[entry.Key].GetType();
    if (listType.IsGenericType)
    {
       var typeArguments = listType.GetGenericArguments();
       //if you only have List<T> in there, you can pull the first one
       var genericType = typeArguments[0];
       if (genericType.IsEnum) {
            // List elements matches...
       }                
    } 
