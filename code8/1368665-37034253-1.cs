    public static object GetObjectByIdOrName(this IEnumerable collection, Mapping mapping)
    {
        foreach(dynamic item in collection)
           if(item.Id == mapping.ObjectId && item.Name == mapping.ObjectName)
               return item;
    }
