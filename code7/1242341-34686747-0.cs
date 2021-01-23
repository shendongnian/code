	public static class MyLinqExtensions
	{
		public static IQueryable<T> InlineFunctions<T>(this IQueryable<T> queryable)
		{
			var expression = TransformExpression(queryable.Expression);
			return (IQueryable<T>)queryable.Provider.CreateQuery(expression);
		}
		private static Expression TransformExpression(System.Linq.Expressions.Expression expression)
		{
			var visitor = new InlineFunctionsExpressionVisitor();
			return visitor.Visit(expression);
		}
		private class InlineFunctionsExpressionVisitor : System.Linq.Expressions.ExpressionVisitor
		{
			protected override System.Linq.Expressions.Expression VisitMethodCall(System.Linq.Expressions.MethodCallExpression methodCallExpression)
			{	
				if (methodCallExpression.Method.IsStatic
					&& methodCallExpression.Method.DeclaringType == typeof(MyDeclaringType)
					&& methodCallExpression.Method.Name == "WhereIsOwnedByUser")
				{
					var setArgumentExpression = methodCallExpression.Arguments[0];
					var userArgumentExpression = methodCallExpression.Arguments[1];
					var methodInfo = ... // Get typeof(IQueryable<Template>).MethodInfo
					var whereConditionExpression = ...// Build where condition and use userArgumentExpression
					return Expression.MethodCallExpression(methodInfo, setArgumentExpression, whereConditionExpression);
				}
				return base.VisitMethodCall(methodCallExpression);
				
				
				// Some ideas to make this more flexible:
				// 1. Use an attribute to mark the functions that can be inlined [InlinableAttribute]
				// 2. Define an Expression<Func<>> first to be able to get the Expression and substritute the function call with it:
				// Expression<Func<IQueryable<Template>, User, IQueryable<Template>>> _whereIsOwnedByUser = (set, user) => 
				// {
				// 	return set.Where(temp => UserOwnsTemplate(user, temp));
				// };
				//
				// public static IQueryable<Template> WhereIsOwnedByUser(this IQueryable<Template> set, User user)
				// {
				//  // You should cache the compiled expression
				//	return _whereIsOwnedByUser.Compile().Invoke(set, user); 
				// }
				//
			}
		}
	}
	
