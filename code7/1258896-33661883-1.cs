	using System;
	public class Program
	{
		public static void Main()
		{
			string sr1 = "0101110";
			string sr2 = "1001110";
			int one = Convert.ToInt32(sr1, 2);
			int two = Convert.ToInt32(sr2, 2);
			int result = one | two;
			Console.WriteLine( Convert.ToString(result, 2)); // "11101");
		}
	}
