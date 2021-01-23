    public static class MyExtensions
    {
    	public static IQueryable<TResult> Select<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector, object options)
    	{
    		var memberInit = (MemberInitExpression)selector.Body;
    		var bindings = new List<MemberBinding>();
    		foreach (var binding in memberInit.Bindings)
    		{
    			var option = options.GetType().GetProperty("Show" + binding.Member.Name);
    			if (option == null || (bool)option.GetValue(options)) bindings.Add(binding);
    		}
    		var newSelector = Expression.Lambda<Func<TSource, TResult>>(
    			Expression.MemberInit(memberInit.NewExpression, bindings), selector.Parameters);
    		return source.Select(newSelector);
    	}
    }
