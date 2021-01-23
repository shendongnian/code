	using System;
	using System.Collections.Generic;
						
	public class Program
	{
		public static void Main()
		{
			
			List<List<List<int>>> myJaggedIntList = new List<List<List<int>>>();
			
			myJaggedIntList.Add(new List<List<int>>());
			myJaggedIntList[0].Add(new List<int>());
			myJaggedIntList[0][0].Add(3);
			
			Console.WriteLine(myJaggedIntList[0][0][0].ToString());
		}
	}
