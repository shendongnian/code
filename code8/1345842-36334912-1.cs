	using System;
	using System.Linq;
	using System.Linq.Expressions;
	public class Program
	{
		public static void Main(string[] args)
		{
			var str = "TestTestTest";
			var propertyName = str.TrimIfRequired<Customer>((c) => c.FirstName);
			var propertyNameValue = str.TrimIfRequired<Customer>((c) => c.Age);
			Console.WriteLine(propertyName);
			Console.WriteLine(propertyNameValue);
		}
	}
	public static class Extensions
	{
		public static string TrimIfRequired<T>(this string str, Expression<Func<T, object>> expr)
		{
			var me = expr.Body as MemberExpression;
			if (me == null && expr.Body is UnaryExpression)
			{
				me = ((UnaryExpression) expr.Body).Operand as MemberExpression;
			}
			if (me == null)
			{
				throw new ArgumentException("Invalid expression. It should be MemberExpression");
			}
			var pi = me.Member;
			var attribute = pi.GetCustomAttributes(typeof(MetaDataFieldAttribute), false).FirstOrDefault() as MetaDataFieldAttribute;
			if (attribute == null) return str;
			int length = attribute.Precision;
			return str.Length > length ? str.Substring(0, length) : str;
		}
	}
	public class Customer
	{
		[MetaDataField(Precision = 6)]
		public string FirstName { get; set; }
		[MetaDataField(Precision = 2)]
		public int Age { get; set; }
	}
	public class MetaDataFieldAttribute : Attribute
	{
		public int Precision { get; set; }
	}
