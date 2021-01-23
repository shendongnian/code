	using System;
	using System.Collections.Generic;
	public class CsvRow
	{
		public CsvRow()
		{
		}
		
		public CsvRow(int a, int b)
		{
			A = a;
			B = b;
		}
		public int A {get; set;}
		public int B {get; set;}
		public override string ToString()
		{
			return String.Format("[{0}, {1}]", A, B);
		}
		
		//OR Note I wouldn't leave both ToStrings in here. 
		
		public string ToString(int rowNumber)
		{
			return String.Format("Row:{0} [{1}, {2}]", rowNumber, A, B);
		}
		
	}
						
	public class Program
	{
		public static void Main()
		{
			var results = new List<CsvRow>();
			results.Add(new CsvRow(1,2));
			results.Add(new CsvRow(2,3));
			
			foreach (var result in results)
			{
				Console.WriteLine(result.ToString());
			}		
			
			var i = 0;
			foreach (var result in results)
			{
				Console.WriteLine(result.ToString(i));
				i++;
			}		
		}
	}
