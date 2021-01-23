    public static class QueryableUtils
    {
    	public static IQueryable<IGrouping<DateTime, T>> GroupBy<T>(this IQueryable<T> source, Expression<Func<T, DateTime>> dateSelector, int minuteInterval)
    	{
    		Expression<Func<DateTime, DateTime, int, DateTime>> expr = (date, baseDate, interval) =>
    			DbFunctions.AddMinutes(baseDate, DbFunctions.DiffMinutes(baseDate, date) / interval).Value;
    		var selector = Expression.Lambda<Func<T, DateTime>>(
    			expr.Body
    			.ReplaceParemeter(expr.Parameters[0], dateSelector.Body)
    			.ReplaceParemeter(expr.Parameters[1], Expression.Constant(DateTime.MinValue))
    			.ReplaceParemeter(expr.Parameters[2], Expression.Constant(minuteInterval))
    			, dateSelector.Parameters[0]
    		);
    		return source.GroupBy(selector);
    	}
    }
