	public static class ExpressionUtils
	{
		public static Expression<Func<T, TMap>> AddCollectionMap<T, TMap, U, UMap>(
			this Expression<Func<T, TMap>> parent,
			Expression<Func<U, UMap>> nav, 
			string propName)
		{
			var parameter = parent.Parameters[0];
			var target = typeof(TMap).GetProperty(propName);
			var source = Expression.Property(parameter, propName);
			var binding = Expression.Bind(target, Expression.Call(
				typeof(Enumerable), "Select", nav.Type.GenericTypeArguments, source, nav));
			var body = parent.Body.AddMemberInitBindings(binding);
			return Expression.Lambda<Func<T, TMap>>(body, parameter);
		}
		static Expression AddMemberInitBindings(this Expression expression, params MemberBinding[] bindings)
		{
			return new AddMemberInitBindingsVisitor { Bindings = bindings }.Visit(expression);
		}
		class AddMemberInitBindingsVisitor : ExpressionVisitor
		{
			public MemberBinding[] Bindings;
			protected override Expression VisitMemberInit(MemberInitExpression node)
			{
				return node.Update(node.NewExpression, node.Bindings.Concat(Bindings));
			}
		}
