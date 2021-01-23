    // Your items
    IEnumerable<object> addedEntities = new object[] { null, null, new int[5], null , new int[1] };
    // The type of the items
    Type type;
    IEnumerable<object> addedEntities2 = addedEntities.GetType(out type);
    MethodInfo method = typeof(EnumerableObject).GetMethod("FilterByUniqueProp2").MakeGenericMethod(type);
    // instead of the second null, you should put your TModel...
    // it isn't clear how it is "built"
    method.Invoke(null, new object[] { addedEntities2, null });
