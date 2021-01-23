	using System;
	public class Program
	{
		
		public static void Main()
		{
			string input = "15300504579PRI03";
			string output = Convert(input); 
			Console.WriteLine(input);
			Console.WriteLine(output);
		}
		
		static public string Convert(string input)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder(input);
			int[] commasAt = {2, 3, 6, 11, 14};
			for(int i = commasAt.Length - 1; i >= 0; i--)	
			{
				sb.Insert(commasAt[i], ',');
			}
			return sb.ToString();
		}
		
	}
