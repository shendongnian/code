		private static void Main(string[] args)
		{
			goo();
			Console.ReadLine();
		}
		private static void foo(Expression e)
		{
			double a, b, c;
			a = 1.0;
			b = 1.0;
			c = 1.0;
			bool result = false;
			var lambdaExpression = ((LambdaExpression)e);
			int count = lambdaExpression.Parameters.Count;
			if (count == 1)
			{
				result = (bool)lambdaExpression.Compile().DynamicInvoke(a);
			}
			else if (count == 2)
			{
				result = (bool)lambdaExpression.Compile().DynamicInvoke(a,b);
			}
			Console.WriteLine(result);
		}
		private static void goo()
		{
			// called as follows:
			foo((Expression<Func<double, bool>>) (x => true));
			foo((Expression<Func<double, double, bool>>) ((x, y) => true));
			foo((Expression<Func<double, double, double, bool>>) ((x, y, z) => true));
		}
