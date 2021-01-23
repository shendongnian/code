	public class Program
	{
		public static void Main(string[] args)
		{
			Expression<Func<Entity, string>> parent = (y) => y.SearchColumn;
			Expression<Func<Entity, string>> sub = (y) => y.Sub.SearchColumn;
			var result = Wrap(parent);
			Console.WriteLine(result);
			result.Compile();
			result = Wrap(sub);
			Console.WriteLine(result);
			result.Compile();
			result = Wrap<Entity>((y) => y.Sub.Sub.Sub.SearchColumn);
			Console.WriteLine(result);
			result.Compile();
		}
		private static Expression<Func<T, bool>> Wrap<T>(Expression<Func<T, string>> accessor)
		{
			var stringContains = typeof (String).GetMethod("Contains", new[] {typeof (String)});
			var pe = Expression.Parameter(typeof (T), "__x4326");
			var newBody = new ParameterReplacer(pe).Visit(accessor.Body);
			var call = Expression.Call(
				newBody,
				stringContains,
				Expression.Constant("foo")
				);
			return Expression.Lambda<Func<T, bool>>(call, pe);
		}
	}
	public class ParameterReplacer : ExpressionVisitor
	{
		private ParameterExpression _target;
		public ParameterReplacer(ParameterExpression target)
		{
			_target = target;
		}
		protected override Expression VisitParameter(ParameterExpression node)
		{
			// here we are replacing original to a new one
			return _target;
		}
	}
	public class Entity
	{
		public string SearchColumn { get; set; }
		public Entity Sub { get; set; }
	}
