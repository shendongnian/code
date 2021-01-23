    using System;
    using System.Linq.Expressions;
    namespace ConsoleApplication1
    {
    	internal sealed class Program
    	{
    		private static void Main(string[] args)
    		{
    			goo();
    			Console.ReadLine();
    		}
    		private static void foo(LambdaExpression e)
    		{
    			double a, b, c;
    			a = 1.0;
    			b = 1.0;
    			c = 1.0;
    			bool result = false;
    			int count = e.Parameters.Count;
    			if (count == 1)
    			{
    				result = (bool)e.Compile().DynamicInvoke(a);
    			}
    			else if (count == 2)
    			{
    				result = (bool)e.Compile().DynamicInvoke(a,b);
    			}
    			Console.WriteLine(result);
    		}
    		private static void goo()
    		{
    			foo((Expression<Func<double, bool>>) (x => true));
    			foo((Expression<Func<double, double, bool>>) ((x, y) => true));
    			foo((Expression<Func<double, double, double, bool>>) ((x, y, z) => true));
    		}
    	}
    }
