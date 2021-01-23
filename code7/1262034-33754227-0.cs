	using System;
	using System.Linq;
						
	public class Program
	{
		public static void Main()
		{
			var name = ""Jean-Paul@@~()"";
			var cleaned_name= new string((from c in name where char.IsLetterOrDigit(c) || c=='-' select c).ToArray());
			Console.WriteLine(cleaned_name);
		}
	}
