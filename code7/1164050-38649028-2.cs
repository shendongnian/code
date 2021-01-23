	public static class FreezeEx
	{
	
		public static Func<List<R>> Freeze<T, R>(this IQueryable<T> queryable, Expression<Func<T, R>> projection)
		{
			return () => queryable.Select(projection).ToList();
		}
		
		public static Func<List<R>> Freeze<T, R>(this IQueryable<T> queryable, Expression<Func<T, bool>> predicate, Expression<Func<T, R>> projection)
		{
			return () => queryable.Where(predicate).Select(projection).ToList();
		}
	}
