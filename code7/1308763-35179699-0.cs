	public static IQueryable<T> WhereEquals<T>(this IQueryable<T> source, T target)
		where T : Entity
	{
		var item = Expression.Parameter(typeof(T), "item");
		var body = Expression.Equal(Expression.Property(item, "Id"), Expression.Constant(target.Id));
		var predicate = Expression.Lambda<Func<T, bool>>(body, item);
		return source.Where(predicate);
	}
