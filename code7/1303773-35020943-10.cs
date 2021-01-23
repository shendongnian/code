    public static IQueryable<Result> GroupBySelector<TSource>(this IQueryable<TSource> source, String column)
    {
		if (source == null) throw new ArgumentNullException("source");
		if (column == null) throw new ArgumentNullException("column");
		if (column.Length == 0) throw new ArgumentException("column");
		var param = Expression.Parameter(typeof(TSource));
		Expression<Func<TSource, string>> keySelector = Expression.Lambda<Func<TSource, string>>
		(
			Expression.Property(param, column),
			param
		);
		return source.GroupBy(keySelector).Select(p => new Result{Value = p.Key, Count = p.Count()});
	}
