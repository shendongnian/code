	public class DataProcessor : IDisposable
	{
		public DataProcessor() { Console.WriteLine("Opened."); }
		public void Dispose() { Console.WriteLine("Closed."); }
		public IEnumerable<Record> GetRecords(int page, int count)
		{
			Console.WriteLine("Reading.");
			Thread.Sleep(100);
			var records = page <= 5
				? Enumerable
					.Range(0, count < 5 ? count : count / 2)
					.Select(x => new Record())
					.ToArray()
				: new Record[] { };
			Console.WriteLine("Read.");
			return records;
		}
	}
	
	public class Record
	{
		private static int __counter = 0;
		public Record() { this.ID = __counter++; }
		public int ID { get; private set; }
	}
	
	public class Result
	{
		public Result(int id) { this.ID = id; }
		public int ID { get; private set; } 
	}
