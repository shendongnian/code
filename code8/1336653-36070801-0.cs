    using System;
    using System.Linq;
    using System.Linq.Expressions;
    
    public static class QueryableUtils
    {
    	public static IQueryable<T> WhereBetween<T>(this IQueryable<T> source, Expression<Func<T, DateTime>> dateSelector, DateTime? startDate, DateTime? endDate)
    	{
    		if (startDate == null && endDate == null) return source;
    		var startCond = startDate != null ? Expression.GreaterThanOrEqual(dateSelector.Body, Expression.Constant(startDate.Value)) : null;
    		var endCond = endDate != null ? Expression.LessThanOrEqual(dateSelector.Body, Expression.Constant(endDate.Value)) : null;
    		var predicate = Expression.Lambda<Func<T, bool>>(
    			startCond == null ? endCond : endCond == null ? startCond : Expression.AndAlso(startCond, endCond),
    			dateSelector.Parameters[0]);
    		return source.Where(predicate);
    	}
    }
