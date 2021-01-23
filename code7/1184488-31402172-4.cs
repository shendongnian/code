    public static IQueryable<T> CurrentVersion(this IQueryable<T> queryable, DateTime date)
    {
        Expression<T,bool> filteringExpression = ExpressionsHelper.CurrentVersion(date);
        return queryable.Where(filteringExpression);
    }
