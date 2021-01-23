    public static object ConvertList(List<object> value, Type type)
    {
        var listType = type.GenericTypeArguments.First();
        return value.Select(item => Convert.ChangeType(item, listType));
    }
