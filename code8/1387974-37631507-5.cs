    public class OrderExpressions<T>
    {
        private readonly Dictionary<string, LambdaExpression> _mappings = 
		    new Dictionary<string, LambdaExpression>();
        public OrderExpressions<T> Add<TKey>(Expression<Func<T, TKey>> expression, string keyword)
        {
            _mappings.Add(keyword, expression);
            return this;
        }
        public LambdaExpression this[string keyword]
        {
            get { return _mappings[keyword]; }
        }
    }
    public static class KeywordSearchExtender
    {
        private static readonly MethodInfo OrderbyMethod;
		private static readonly MethodInfo OrderbyDescendingMethod;
		private static readonly MethodInfo ThenByMethod;
		private static readonly MethodInfo ThenByDescendingMethod;
		//Here we use reflection to get references to the open generic methods for
		//the 4 Queryable methods that we need
		static KeywordSearchExtender()
		{
			OrderbyMethod = typeof(Queryable)
				.GetMethods()
				.First(x => x.Name == "OrderBy" &&
					x.GetParameters()
						.Select(y => y.ParameterType.GetGenericTypeDefinition())
						.SequenceEqual(new[] { typeof(IQueryable<>), typeof(Expression<>) }));
			OrderbyDescendingMethod = typeof(Queryable)
				.GetMethods()
				.First(x => x.Name == "OrderByDescending" &&
					x.GetParameters()
						.Select(y => y.ParameterType.GetGenericTypeDefinition())
						.SequenceEqual(new[] { typeof(IQueryable<>), typeof(Expression<>) }));
			ThenByMethod = typeof(Queryable)
				.GetMethods()
				.First(x => x.Name == "ThenBy" &&
					x.GetParameters()
						.Select(y => y.ParameterType.GetGenericTypeDefinition())
						.SequenceEqual(new[] { typeof(IOrderedQueryable<>), typeof(Expression<>) }));
			ThenByDescendingMethod = typeof(Queryable)
				.GetMethods()
				.First(x => x.Name == "ThenByDescending" &&
					x.GetParameters()
						.Select(y => y.ParameterType.GetGenericTypeDefinition())
						.SequenceEqual(new[] { typeof(IOrderedQueryable<>), typeof(Expression<>) }));
		}
		//This method can invoke OrderBy or the other methods without
		//getting as input the expression return value type
		private static IQueryable<T> InvokeQueryableMethod<T>(
			MethodInfo methodinfo,
			IQueryable<T> queryable,
			LambdaExpression expression)
		{
			var generic_order_by =
				methodinfo.MakeGenericMethod(
					typeof(T),
					expression.ReturnType);
			return (IQueryable<T>)generic_order_by.Invoke(
				null,
				new object[] { queryable, expression });
		}
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> data, 
		    OrderExpressions<T> mapper, params string[] arguments)
        {
            if (arguments.Length == 0)
                throw new ArgumentException(@"You need at least one argument!", "arguments");
            List<SortArgument> sorting = arguments.Select(a => new SortArgument(a)).ToList();
            IQueryable<T> result = null;
            for (int i = 0; i < sorting.Count; i++)
            {
                SortArgument sort = sorting[i];
                LambdaExpression lambda = mapper[sort.Keyword];
                if (i == 0)
                    result = InvokeQueryableMethod(sort.Ascending ? 
					    OrderbyMethod : OrderbyDescendingMethod, data, lambda);
                else
                    result = InvokeQueryableMethod(sort.Ascending ? 
					    ThenByMethod : ThenByDescendingMethod, result, lambda);
            }
            return result;
        }
    }
    public class SortArgument
    {
        public SortArgument()
        { }
        public SortArgument(string term)
        {
            if (term.StartsWith("-"))
            {
                Ascending = false;
                Keyword = term.Substring(1);
            }
            else if (term.StartsWith("+"))
            {
                Ascending = true;
                Keyword = term.Substring(1);
            }
            else
            {
                Ascending = true;
                Keyword = term;
            }
        }
        public string Keyword { get; set; }
        public bool Ascending { get; set; }
    }
