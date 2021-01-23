    public static class QueryableUtils
    {
    	public static Func<IQueryable<TSource>, IOrderedQueryable<TSource>> OrderByFunc<TSource>(string propertyName, bool ascending = true)
    	{
    		var source = Expression.Parameter(typeof(IQueryable<TSource>), "source");
    		var item = Expression.Parameter(typeof(TSource), "item");
    		var member = Expression.Property(item, propertyName);
    		var selector = Expression.Quote(Expression.Lambda(member, item));
    		var body = Expression.Call(
    			typeof(Queryable), ascending ? "OrderBy" : "OrderByDescending",
    			new Type[] { item.Type, member.Type },
    			source, selector);
    		var expr = Expression.Lambda<Func<IQueryable<TSource>, IOrderedQueryable<TSource>>>(body, source);
    		var func = expr.Compile();
    		return func;
    	}
    }
