    public class ExpressionMap
    {
    	private Dictionary<Type, Type> typeMap = new Dictionary<Type, Type>();
    	private Dictionary<MemberInfo, Expression> memberMap = new Dictionary<MemberInfo, Expression>();
    	public ExpressionMap Add<TFrom, TTo>()
    	{
    		typeMap.Add(typeof(TFrom), typeof(TTo));
    		return this;
    	}
    	public ExpressionMap Add<TFrom, TFromMember, TTo, TToMember>(Expression<Func<TFrom, TFromMember>> from, Expression<Func<TTo, TToMember>> to)
    	{
    		memberMap.Add(((MemberExpression)from.Body).Member, to.Body);
    		return this;
    	}
    	public Expression Map(Expression source) => new MapVisitor { map = this }.Visit(source);
    
    	private class MapVisitor : ExpressionVisitor
    	{
    		public ExpressionMap map;
    		private Dictionary<Type, ParameterExpression> parameterMap = new Dictionary<Type, ParameterExpression>();
    		protected override Expression VisitLambda<T>(Expression<T> node)
    		{
    			return Expression.Lambda(Visit(node.Body), node.Parameters.Select(Map));
    		}
    		protected override Expression VisitParameter(ParameterExpression node) => Map(node);
    		protected override Expression VisitMember(MemberExpression node)
    		{
    			var expression = Visit(node.Expression);
    			if (expression == node.Expression)
    				return node;
    			Expression mappedMember;
    			if (map.memberMap.TryGetValue(node.Member, out mappedMember))
    				return Visit(mappedMember);
    			return Expression.PropertyOrField(expression, node.Member.Name);
    		}
    		protected override Expression VisitMethodCall(MethodCallExpression node)
    		{
    			if (node.Object == null && node.Method.IsGenericMethod)
    			{
    				// Static generic method
    				var arguments = Visit(node.Arguments);
    				var genericArguments = node.Method.GetGenericArguments().Select(Map).ToArray();
    				var method = node.Method.GetGenericMethodDefinition().MakeGenericMethod(genericArguments);
    				return Expression.Call(method, arguments);
    			}
    			return base.VisitMethodCall(node);
    		}
    		private Type Map(Type type)
    		{
    			Type mappedType;
    			return map.typeMap.TryGetValue(type, out mappedType) ? mappedType : type;
    		}
    		private ParameterExpression Map(ParameterExpression parameter)
    		{
    			var mappedType = Map(parameter.Type);
    			ParameterExpression mappedParameter;
    			if (!parameterMap.TryGetValue(mappedType, out mappedParameter))
    				parameterMap.Add(mappedType, mappedParameter = Expression.Parameter(mappedType, parameter.Name));
    			return mappedParameter;
    		}
    	}
    }
