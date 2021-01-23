		private static IEnumerable<Product> SearchArrayQueryLinq(IEnumerable<string> names)
		{
			using (var context = new NORTHWNDEntities())
			{
				return context.Products.Where(GetCombinedOrFilter(names)).ToList();
			}
		}
		private static Expression<Func<Product, bool>> GetCombinedOrFilter(IEnumerable<string> names)
		{
			var filter = GetNameFilter(names.First());
			foreach (var name in names.Skip(1))
				filter = CombineFiltersAsOr(filter, GetNameFilter(name));
			return filter;
		}
		private static Expression<Func<Product, bool>> GetNameFilter(string name)
		{
			return product => product.ProductName.Contains(name);
		}
		private static Expression<Func<Product, bool>> CombineFiltersAsOr(Expression<Func<Product, bool>> x, Expression<Func<Product, bool>> y)
		{
			// Combine two separate expressions into one by combining as "Or". In order for this to work, instead of there being a parameter
			// for each expression, the parameter from the first expression must be shared between them both (otherwise things will go awry
			// when this is translated into a database query) - this is why ParameterRebinder.ReplaceParameters is required.
			var expressionParameter = x.Parameters.Single();
			return Expression.Lambda<Func<Product, bool>>(
				Expression.Or(x.Body, ParameterRebinder.ReplaceParameters(y.Body, toReplace: y.Parameters.Single(), replaceWith: expressionParameter)),
				expressionParameter
			);
		}
		// Borrowed and tweaked from https://blogs.msdn.microsoft.com/meek/2008/05/02/linq-to-entities-combining-predicates/
		public sealed class ParameterRebinder : ExpressionVisitor
		{
			public static Expression ReplaceParameters(Expression expression, ParameterExpression toReplace, ParameterExpression replaceWith)
			{
				return new ParameterRebinder(toReplace, replaceWith).Visit(expression);
			}
			private readonly ParameterExpression _toReplace, _replaceWith;
			private ParameterRebinder(ParameterExpression toReplace, ParameterExpression replaceWith)
			{
				_toReplace = toReplace;
				_replaceWith = replaceWith;
			}
			protected override Expression VisitParameter(ParameterExpression p)
			{
				if (p == _toReplace)
					p = _replaceWith;
				return base.VisitParameter(p);
			}
		}
