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
        var addRange = resultType.GetMethod("AddRange");
        result = addRange.Invoke(result, new object[] { collection });
        return result;
    }
