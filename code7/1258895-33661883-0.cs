	using System;
	public class Program
	{
		public static void Main()
		{
			string sr1 = "0101110";
			string sr2 = "1101110";
			int one = Convert.ToInt32(sr1, 2);
			int two = Convert.ToInt32(sr2, 2);
			int result = one | two;
			Console.WriteLine(BinaryString(result));
		}
		public static string BinaryString(int x)
		{
			char[] bits = new char[32];
			int i = 0;
			while (x != 0)
			{
				bits[i++] = (x & 1) == 1 ? '1' : '0';
				x >>= 1;
			}
			Array.Reverse(bits, 0, i);
			return new string (bits);
		}
	}
