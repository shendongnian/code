	public static IQueryable<T> ForList<T, K>(this IQueryable<T> items, List<K> list,
        Func<Expression<Func<T, bool>>, K, Expression<Func<T, bool>>> condition)
	{
		var predicate = PredicateBuilder.False<T>();
		foreach (var item in list)
		{
			var tmp = item;	// local copy for deferred execution
			predicate = condition(predicate, tmp);
		}
		return items.AsExpandable().Where(predicate);
	}
