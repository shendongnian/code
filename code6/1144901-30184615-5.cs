	namespace My
	{
		using System.Linq;
		using System.Linq.Expressions;
		public class MyExpressionManipulator : ExpressionVisitor
		{
			protected override Expression VisitMethodCall(MethodCallExpression node)
			{
				if (node.Method.DeclaringType == typeof(Queryable) && node.Method.Name == "Where" && node.Arguments.Count == 2)
				{
					// Transforms all the .Where(x => something) in
					// .Where(x => something && something)
					if (node.Arguments[1].NodeType == ExpressionType.Quote)
					{
						UnaryExpression argument1 = (UnaryExpression)node.Arguments[1]; // Expression.Quote
						if (argument1.Operand.NodeType == ExpressionType.Lambda)
						{
							LambdaExpression argument1lambda = (LambdaExpression)argument1.Operand;
							// Important: at each step you'll reevalute the
							// full expression! Try to not replace twice
							// the expression!
							// So if you have a query like:
							// var res = ctx.Where(x => true).Where(x => true).Select(x => 1)
							// the first time you'll visit
							//  ctx.Where(x => true)
							// and you'll obtain
							//  ctx.Where(x => true && true)
							// the second time you'll visit
							//  ctx.Where(x => true && true).Where(x => true)
							// and you want to obtain
							//  ctx.Where(x => true && true).Where(x => true && true)
							// and not
							//  ctx.Where(x => (true && true) && (true && true)).Where(x => true && true)
							if (argument1lambda.Body.NodeType != ExpressionType.AndAlso)
							{
								var arguments = new Expression[node.Arguments.Count];
								node.Arguments.CopyTo(arguments, 0);
								arguments[1] = Expression.Quote(Expression.Lambda(Expression.AndAlso(argument1lambda.Body, argument1lambda.Body), argument1lambda.Parameters));
								MethodCallExpression node2 = Expression.Call(node.Object, node.Method, arguments);
								node = node2;
							}
						}
					}
				}
				return base.VisitMethodCall(node);
			}
		}
	}
