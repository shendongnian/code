    internal static IQueryable<TestItemTable> WhereFilter(this IQueryable<TestItemTable> source, Expression<Func<TestItemTable, DateTime>> fieldData, DateTime? dateIsBefore, DateTime? dateIsAfter)
    {
        source = source.AsExpandable().Where(record => ((!dateIsAfter.HasValue
                || fieldData.Invoke(record) > dateIsAfter.Value)
                && (!dateIsBefore.HasValue
                || fieldData.Invoke(record) < dateIsBefore.Value)));
    
        return source;
    }
