	using System;
	using System.Linq.Expressions;
	public class Program
	{
		public static void Main(string[] args)
		{
			ParameterExpression param = Expression.Parameter(typeof(Test), "obj");
			Expression a = Expression.Property(param, "A");
			Expression b = Expression.Property(param, "B");
			Expression result = CustomCombine(a, b);
			var lambda = Expression.Lambda<Func<Test, int>>(result, new ParameterExpression[] { param });
			Func<Test, int> func = lambda.Compile();
			var obj = new Test();
			var val = func(obj);
			Console.WriteLine("Result is " + val);
		}
		private static Expression CustomCombine(Expression a, Expression b)
		{
			var variable = Expression.Variable(a.Type, "cached");
			var aVal = Expression.Assign(variable, a);
			var mult = Expression.Multiply(variable, b);
			var result = Expression.Add(mult, variable);
			// here we are making Block with variable declaration and assigment
			var block = Expression.Block(new ParameterExpression[]{variable}, aVal, result);
			return block;
		}
	}
	public class Test
	{
		public int A
		{
			get
			{
				Console.WriteLine("Property A is accessed");
				return 42;
			}
		}
		public int B
		{
			get
			{
				return 1;
			}
		}
	}
