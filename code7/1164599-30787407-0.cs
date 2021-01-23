    public static Func<DbResult, string[]> GetProperties(IEnumerable<string> propertyNames)
    {
        return item => propertyNames.Select(name => item.Value(name))
            .ToArray();
    }
