    public IQueryable<T> List<T>(string columnName, string value, string order)
       where T : class
    {
        return context.Set<T>().Where(columnName + " = @0", value).OrderBy(order);
    }
