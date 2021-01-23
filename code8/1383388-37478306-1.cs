	class Program
	{
		static void Main(string[] args)
		{
			int s = 10;
            // the function we're passing as a parameter will multiply them
            // then return the result
			int t = s.CreatedMethod((param1, param2) => param1 * param2);
            // or you can use this since the method signature matches:
            // int t = s.CreatedMethod(RegularMethod);
			Console.WriteLine(t.ToString()); // outputs "60"
			Console.ReadLine();
		}
    	static int RegularMethod(int v1, int v2)
    	{
        	return v1 * v2; // <-- I also wanted to multiply int 's' like this s*v1*v2
    	}
	}
	public static class Extension
	{
		public static int CreatedMethod(this int number, Func<int, int, int> fn)
		{
			return number * fn.Invoke(2, 3);
		}
	}
