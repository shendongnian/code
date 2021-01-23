	void Main()
	{
		var foo = new Foo();
		
		var qux = NullPropertyExtension.GetValue(() => foo.Bar.Qux);
		
		Console.WriteLine(qux);
		
		
	}
	
	public class Foo
	{
		public Foo Bar { get; set; }
		public string Qux {get;set;}
	}
	
	// Define other methods and classes here
	public static class NullPropertyExtension
	{
		public static TValue GetValue<TValue>(Expression<Func<TValue>> property)
		{
			var visitor = new Visitor();
			var expression = visitor.Visit(property.Body);
			var lambda = Expression.Lambda<Func<TValue>>(expression);
			
			var func = lambda.Compile();
			return func();
		}
		
		private class Visitor : System.Linq.Expressions.ExpressionVisitor
		{
			protected override Expression VisitMember(MemberExpression node)
			{
				var isNotNull = Expression.NotEqual(node.Expression, Expression.Constant(null));
				return Expression.Condition(
					isNotNull,
					node,
					Expression.Constant(null, node.Type));
				
			}
		}
	}
