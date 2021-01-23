	static class MyConsole 
	{
		public static System.IO.TextReader In { get; set; }
		public static string ReadLine()
		{
			return In.ReadLine ();
		}
		public static void WriteLine(string line)
		{
			Console.WriteLine (line);
		}
	}
