	public class CsvRow
	{
		public CsvRow()
		{
		}
		
		public CsvRow(string a, string b)
		{
			A = a;
			B = b;
		}
		public string A {get; set;}
		public string B {get; set;}
		
		public string ToString(int rowNumber)
		{
			return String.Format("Row{0}: {1} {2}", rowNumber, A, B);
		}
		
	}
						
	public class Program
	{
		public static void Main()
		{
			var results = new List<CsvRow>();
			results.Add(new CsvRow(DateTime.Now.ToString(), "200"));
			results.Add(new CsvRow(DateTime.Now.ToString(), "300"));			
			
			var i = 0;
			foreach (var result in results)
			{
				Console.WriteLine(result.ToString(i));
				i++;
			}		
		}
	}
	
