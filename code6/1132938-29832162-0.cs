	class Program
	{
		static void Main(string[] args)
		{
			var abc = new int[] { 1, 2, 3, 4, 5 };
			var result = from a in abc
						 from b in abc
						 from c in abc
						 where a != b && a != c && b != c
						 select new { a, b, c };
			foreach(var r in result)
				Console.WriteLine (r);
			Console.Read();
		}
	}
