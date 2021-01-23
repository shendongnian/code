	public static Expression<Func<TEntity, bool>> Wrap<TEntity>(Func<TEntity, bool> func)
	{
		var entity = Expression.Parameter(typeof(TEntity));
		return 
			Expression.Lambda<Func<TEntity, bool>>
			(
				Expression.Invoke(Expression.Constant(func), entity), 
				entity
			);
	}
