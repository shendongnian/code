    // this is a slightly changed and not tested version from the source
    public static IEnumerable<T> WhereQuery(this IEnumerable<T> source, string columnName, string propertyValue)
    {
        return source.Where(m => { 
            return m.GetType().GetProperty(columnName).GetValue(m, null).ToString().Contains(propertyValue); 
        });
    }
