    public static class QueryableExtensions
    {
    	public static IQueryable<T> WhereIn<T>(IQueryable<T> source, Expression<Func<T, DateTime>> dateSelector, IEnumerable<Range<DateTime>> ranges)
    	{
    		var filter = ranges == null ? null : ranges.Select(range =>
    		{
    			var startFilter = range.Start != null ? Expression.GreaterThanOrEqual(dateSelector.Body, Expression.Constant(range.Start.Value.Date)) : null;
    			var endFilter = range.End != null ? Expression.LessThan(dateSelector.Body, Expression.Constant(range.End.Value.Date.AddDays(1))) : null;
    			return startFilter == null ? endFilter : endFilter == null ? startFilter : Expression.AndAlso(startFilter, endFilter);
    		})
    		.Where(item => item != null)
    		.Aggregate(Expression.OrElse);
    		return filter != null ? source.Where(Expression.Lambda<Func<T, bool>>(filter, dateSelector.Parameters[0])) : source;
    	}
    }
