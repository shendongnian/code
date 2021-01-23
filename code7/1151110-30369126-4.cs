    using System;
	using System.Collections.Generic;
						
	public class Program
	{
		public static void Main()
		{
			String StringInput = "Input";
			
			List<int> ListInput = new List<int>();
			
			ListInput.Add(1);
			ListInput.Add(2);
			ListInput.Add(3);
			
			Console.WriteLine(StringInput);
			
			ChangeMyObject(StringInput);
			
			Console.WriteLine(StringInput);
			
			
			Console.WriteLine(ListInput.Count.ToString());
			
			ChangeMyObject(ListInput);
			
			Console.WriteLine(ListInput.Count.ToString());
			
			
			
			ChangeMyObject(ref StringInput);
			
			Console.WriteLine(StringInput);
			
			ChangeMyObject(ref ListInput);
			
			Console.WriteLine(ListInput.Count.ToString());
			
			
			
		}
		
		static void ChangeMyObject(String input)
		{
			
			input = "Output";
		}
		
		static void ChangeMyObject(ref String input)
		{
			
			input = "Output";
		}
		
		
		static void ChangeMyObject(List<int> input)
		{
			
			input = new List<int>();
		}
		
		static void ChangeMyObject(ref List<int> input)
		{
			
			input = new List<int>();
		}
		
		
	}
