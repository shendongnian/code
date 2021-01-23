	internal class Program
	{
		private static void Main(string[] args)
		{
			Filter filter = new Filter();
			filter.Operator = ">";
			filter.Value = "42";
			filter.PropertyName = "Prop1";
			ParameterExpression expr = Expression.Parameter(typeof (Test), "x");
			var resultExpr = ExpressionBuilder.GetExpression<decimal>(expr, filter);
			// and it will hold such expression:
			// {(Convert(x.Prop1) > Convert(ChangeType(Convert("42"), System.Decimal)))}
			Console.WriteLine(expr.ToString());
		}
	}
	public class Test
	{
		public int Prop1 { get; set; }
	}
	public static class ExpressionBuilder
	{
		private static readonly MethodInfo containsMethod = typeof (string).GetMethod("Contains");
		private static readonly MethodInfo startsWithMethod = typeof (string).GetMethod("StartsWith",
			new Type[] {typeof (string)});
		private static readonly MethodInfo endsWithMethod = typeof (string).GetMethod("EndsWith", new Type[] {typeof (string)});
		private static readonly MethodInfo changeTypeMethod = typeof (Convert).GetMethod("ChangeType",
			new Type[] {typeof (object), typeof (Type)});
		public static Expression GetExpression<T>(ParameterExpression param, Filter filter)
		{
			//the property that I access here is stored as a string
			MemberExpression member = Expression.Property(param, filter.PropertyName);
			//this value is brought in from a web request as a string, but could be a numeric, datetime, or other type
			ConstantExpression constant = Expression.Constant(filter.Value);
			Expression targetValue;
			Expression sourceValue;
			if (filter.Value != null && member.Type == filter.Value.GetType() && member.Type == typeof(T))
			{
				targetValue = constant;
				sourceValue = member;
			}
			else
			{
				var targetType = Expression.Constant(typeof(T));
				targetValue = Convert(constant, typeof(object));
				sourceValue = Convert(member, typeof(object));
				targetValue = Expression.Call(changeTypeMethod, targetValue, targetType);
				sourceValue = Expression.Call(changeTypeMethod, sourceValue, targetType);
				targetValue = Convert(targetValue, member.Type);
				sourceValue = Convert(member, member.Type);
			}
			try
			{
				switch (filter.Operation)
				{
					case Enums.Op.Equals:
						return Expression.Equal(sourceValue, targetValue);
					case Enums.Op.NotEqual:
						return Expression.NotEqual(sourceValue, targetValue);
					case Enums.Op.Contains:
						return Expression.Call(sourceValue, containsMethod, targetValue);
					case Enums.Op.StartsWith:
						return Expression.Call(sourceValue, startsWithMethod, targetValue);
					case Enums.Op.EndsWith:
						return Expression.Call(sourceValue, endsWithMethod, targetValue);
					case Enums.Op.GreaterThan:
						return Expression.GreaterThan(sourceValue, targetValue);
				}
			}
			catch (Exception ex)
			{
				throw;
			}
			return null;
		}
		private static Expression Convert(Expression from, Type type)
		{
			return Expression.Convert(from, type);
		}
	}
	public class Filter
	{
		public string PropertyName { get; set; }
		public int Key { get; set; }
		public string Operator { get; set; }
		public Enums.Op Operation
		{
			get
			{
				switch (Operator.Trim())
				{
					case "<=":
						return Enums.Op.LessThanOrEqual;
					case ">=":
						return Enums.Op.GreaterThanOrEqual;
					case "=":
						return Enums.Op.Equals;
					case "<":
						return Enums.Op.LessThan;
					case ">":
						return Enums.Op.GreaterThan;
					case "not equal to":
						return Enums.Op.NotEqual;
					case "contains":
						return Enums.Op.Contains;
					case "starts with":
						return Enums.Op.StartsWith;
					case "ends with":
						return Enums.Op.EndsWith;
					default:
						return new Enums.Op();
				}
			}
		}
		public object Value { get; set; }
	}
	public class Enums
	{
		public enum Op
		{
			LessThanOrEqual,
			GreaterThanOrEqual,
			Equals,
			LessThan,
			GreaterThan,
			NotEqual,
			Contains,
			StartsWith,
			EndsWith
		}
	}
