    public IQueryable<T> OrderResults<T, TU>(IQueryable<T> queryData, IComparer<TU> customComparer, string sortColumnName)
    {
        var sortPropertyInfo = queryData.First().GetType().GetProperty(sortColumnName);
        return queryData.OrderBy(x => (TU)sortPropertyInfo.GetValue(x, null), customComparer);
    }
