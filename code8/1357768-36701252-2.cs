    public static class QueryableExtensions
    {
    	public static IQueryable<IGrouping<GroupKey<K1, K2>, T>> GroupByPair<T, K1, K2>(this IQueryable<T> source, Expression<Func<T, K1>> keySelector1, Expression<Func<T, K2>> keySelector2)
    	{
    		var parameter = keySelector1.Parameters[0];
    		var key1 = keySelector1.Body;
    		var key2 = keySelector2.Body.ReplaceParameter(keySelector2.Parameters[0], parameter);
    		var keyType = typeof(GroupKey<K1, K2>);
    		var keySelector = Expression.Lambda<Func<T, GroupKey<K1, K2>>>(
    			Expression.MemberInit(
    				Expression.New(keyType),
    				Expression.Bind(keyType.GetProperty("Key1"), key1),
    				Expression.Bind(keyType.GetProperty("Key2"), key2)),
    			parameter);
    		return source.GroupBy(keySelector);
    	}
    }
