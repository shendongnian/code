    public static partial class QueryableExtensions
    {
    	public static IQueryable<T> ReduceConstPredicates<T>(this IQueryable<T> source)
    	{
    		var visitor = new ConstPredicateReducer();
    		var expression = visitor.Visit(source.Expression);
    		if (expression != source.Expression)
    			return source.Provider.CreateQuery<T>(expression);
    		return source;
    	}
    
    	class ConstPredicateReducer : ExpressionVisitor
    	{
    		int evaluateConst;
    		private ConstantExpression TryEvaluateConst(Expression node)
    		{
    			evaluateConst++;
    			try { return Visit(node) as ConstantExpression; }
    			finally { evaluateConst--; }
    		}
    		protected override Expression VisitConditional(ConditionalExpression node)
    		{
    			var testConst = TryEvaluateConst(node.Test);
    			if (testConst != null)
    				return Visit((bool)testConst.Value ? node.IfTrue : node.IfFalse);
    			return base.VisitConditional(node);
    		}
    		protected override Expression VisitBinary(BinaryExpression node)
    		{
    			if (node.Type == typeof(bool))
    			{
    				var leftConst = TryEvaluateConst(node.Left);
    				var rightConst = TryEvaluateConst(node.Right);
    				if (leftConst != null || rightConst != null)
    				{
    					if (node.NodeType == ExpressionType.AndAlso)
    					{
    						if (leftConst != null) return (bool)leftConst.Value ? (rightConst ?? Visit(node.Right)) : Expression.Constant(false);
    						return (bool)rightConst.Value ? Visit(node.Left) : Expression.Constant(false);
    					}
    					else if (node.NodeType == ExpressionType.OrElse)
    					{
    
    						if (leftConst != null) return !(bool)leftConst.Value ? (rightConst ?? Visit(node.Right)) : Expression.Constant(true);
    						return !(bool)rightConst.Value ? Visit(node.Left) : Expression.Constant(true);
    					}
    					else if (leftConst != null && rightConst != null)
    					{
    						var result = Expression.Lambda<Func<bool>>(Expression.MakeBinary(node.NodeType, leftConst, rightConst)).Compile().Invoke();
    						return Expression.Constant(result);
    					}
    				}
    			}
    			return base.VisitBinary(node);
    		}
    		protected override Expression VisitMethodCall(MethodCallExpression node)
    		{
    			if (evaluateConst > 0)
    			{
    				var objectConst = node.Object != null ? TryEvaluateConst(node.Object) : null;
    				if (node.Object == null || objectConst != null)
    				{
    					var arguments = new object[node.Arguments.Count];
    					bool canEvaluate = true;
    					for (int i = 0; i < arguments.Length; i++)
    					{
    						var argumentConst = TryEvaluateConst(node.Arguments[i]);
    						if (canEvaluate = (argumentConst != null))
    							arguments[i] = argumentConst.Value;
    						else
    							break;
    					}
    					if (canEvaluate)
    					{
    						var result = node.Method.Invoke(objectConst != null ? objectConst.Value : null, arguments);
    						return Expression.Constant(result, node.Type);
    					}
    				}
    			}
    			return base.VisitMethodCall(node);
    		}
    		protected override Expression VisitUnary(UnaryExpression node)
    		{
    			if (evaluateConst > 0 && (node.NodeType == ExpressionType.Convert || node.NodeType == ExpressionType.ConvertChecked))
    			{
    				var operandConst = TryEvaluateConst(node.Operand);
    				if (operandConst != null)
    				{
    					var result = Expression.Lambda(node.Update(operandConst)).Compile().DynamicInvoke();
    					return Expression.Constant(result, node.Type);
    				}
    			}
    			return base.VisitUnary(node);
    		}
    		protected override Expression VisitMember(MemberExpression node)
    		{
    			object value;
    			if (evaluateConst > 0 && TryGetValue(node, out value))
    				return Expression.Constant(value, node.Type);
    			return base.VisitMember(node);
    		}
    		static bool TryGetValue(MemberExpression me, out object value)
    		{
    			object source = null;
    			if (me.Expression != null)
    			{
    				if (me.Expression.NodeType == ExpressionType.Constant)
    					source = ((ConstantExpression)me.Expression).Value;
    				else if (me.Expression.NodeType != ExpressionType.MemberAccess
    					|| !TryGetValue((MemberExpression)me.Expression, out source))
    				{
    					value = null;
    					return false;
    				}
    			}
    			if (me.Member is PropertyInfo)
    				value = ((PropertyInfo)me.Member).GetValue(source);
    			else
    				value = ((FieldInfo)me.Member).GetValue(source);
    			return true;
    		}
    	}
    }
