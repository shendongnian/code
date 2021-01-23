    public static IQueryable<T> SortByParams<T>(this IQueryable<T> source, List<SortBy> sorting)
    {
    	var queryExpr = source.Expression;
    	string methodAsc = "OrderBy";
    	string methodDesc = "OrderByDescending";
    	foreach (var item in sorting)
    	{
    		var selectorParam = Expression.Parameter(typeof(T), "e");
    		var selector = Expression.Lambda(Expression.PropertyOrField(selectorParam, item.columnName), selectorParam);
    		var method = string.Equals(item.sortDir, "desc", StringComparison.OrdinalIgnoreCase) ? methodDesc : methodAsc;
    		queryExpr = Expression.Call(typeof(Queryable), method,
    			new Type[] { selectorParam.Type, selector.Body.Type },
    			queryExpr, Expression.Quote(selector));
    		methodAsc = "ThenBy";
    		methodDesc = "ThenByDescending";
    	}
    	return source.Provider.CreateQuery<T>(queryExpr);
    }
