    void Main()
    {
        object il = CreateImmutableList(new[] { 1, 2, 3, 4, 5 }, typeof(int));
        il.GetType().Dump();
        il.Dump();
    }
    
    public static object CreateImmutableList(IEnumerable collection, Type elementType)
    {
        // TODO: guard clauses for parameters == null
        var resultType = typeof(ImmutableList<>).MakeGenericType(elementType);
        var result = resultType.GetField("Empty").GetValue(null);
        var add = resultType.GetMethod("Add");
        foreach (var element in collection)
            result = add.Invoke(result, new object[] { element });
        return result;
    }
