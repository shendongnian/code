    public class PropertyHelper
    	{
    		public static string GetName<T>(Expression<Func<T>> expression)
    		{
    			return GetName(expression.Body);
    		}
    
    		public static string GetName<T>(Expression<Func<T, object>> expression)
    		{
    			return GetName(expression.Body);
    		}
    
    		public static string GetName<T, TProperty>(Expression<Func<T, TProperty>> expression)
    		{
    			return GetName(expression.Body);
    		}
    
    		public static Type GetType<T>(Expression<Func<T, object>> expression)
    		{
    			return GetMemberExpression(expression.Body).Type;
    		}
    
    		public static Type GetType<T, TProperty>(Expression<Func<T, TProperty>> expression)
    		{
    			return GetMemberExpression(expression.Body).Type;
    		}
    
    		private static MemberExpression GetMemberExpression(Expression expression)
    		{
    			var getMemberExpression = expression as MemberExpression;
    
    			if (getMemberExpression != null)
    				return getMemberExpression;
    
    			if (IsConversion(expression))
    			{
    				var unaryExpression = expression as UnaryExpression;
    
    				if (unaryExpression != null)
    					return GetMemberExpression(unaryExpression.Operand);
    			}
    
    			return null;
    		}
    
    		private static string GetName(Expression expression)
    		{
    			return string.Join(".", GetNames(expression));
    		}
    
    		private static IEnumerable<string> GetNames(Expression expression)
    		{
    			var memberExpression = GetMemberExpression(expression);
    
    			if (memberExpression == null)
    				yield break;
    
    			foreach (var memberName in GetNames(memberExpression.Expression))
    				yield return memberName;
    
    			yield return memberExpression.Member.Name;
    		}
    
    		private static bool IsConversion(Expression expression)
    		{
    			return (expression.NodeType == ExpressionType.Convert
    			        || expression.NodeType == ExpressionType.ConvertChecked);
    		}
    	}
