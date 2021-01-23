	class Program
	{
		static void Main(string[] args)
		{
			int s = 10;
            // the function we're passing as a parameter will mutiply them
            // then return the result
			int t = s.CreatedMethod((param1, param2) => param1 * param2);
			Console.WriteLine(t.ToString()); // outputs "60"
			Console.ReadLine();
		}
	}
	public static class Extension
	{
		public static int CreatedMethod(this int number, Func<int, int, int> fn)
		{
			return number * fn.Invoke(2, 3);
		}
	}
