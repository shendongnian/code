    public static IQueryable<Result> GroupBySelector<TSource>(this IQueryable<TSource> source, String column)
    {
		if (source == null) throw new ArgumentNullException("source");
		if (column == null) throw new ArgumentNullException("column");
		if (column.Length == 0) throw new ArgumentException("column");
		var param = Expression.Parameter(typeof(TSource));
		var prop = Expression.Property(param, column);
		if (prop.Type != typeof(string)) throw new ArgumentException("'" + column + "' identifies a property of type '" + prop.Type + "', not a string property.", "column");
		Expression<Func<TSource, string>> keySelector = Expression.Lambda<Func<TSource, string>>
		(
			prop,
			param
		);
		return source.GroupBy(keySelector).Select(p => new Result{Value = p.Key, Count = p.Count()});
	}
