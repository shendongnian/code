	internal static class Program
	{
		public static int MaxA(int value, int max)
		{
			return value > max ? max : value;
		}
		public static int MaxB(int value, int max)
		{
			if (value > max)
				return max;
			else
				return value;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int TestA(int a, int b)
		{
			return MaxA(a, b);
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int TestB(int a, int b)
		{
			return MaxB(a, b);
		}
		private static void Main()
		{
			var rand = new Random();
			var a = rand.Next();
			var b = rand.Next();
			var result = TestA(a, b);
			Console.WriteLine(result);
			result = TestB(a, b);
			Console.WriteLine(result);
		}
	}
