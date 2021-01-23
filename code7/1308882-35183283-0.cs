	using System;
	using System.Linq;
	using System.Collections.Generic;
						
	public class Program
	{
		public static void Main()
		{
			string source = "1234567891234567";
			int chunkSize = 4;
			
			List<string> chunks = (from i in source.ToCharArray().Select((value, index) => new { Value = value, Index = index })
									  group i.Value by i.Index / chunkSize into g
									  select g).Select(x => string.Join("",x)).ToList();
			
			
			Console.WriteLine(string.Join("-",chunks));
			Console.WriteLine("XXXX-XXXX-XXXX-"+chunks.Last());
			Console.WriteLine(chunks.First()+"-XXXX-XXXX-"+chunks.Last());
		}
	}
