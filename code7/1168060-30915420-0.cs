	public class Document
	{
		public List<Group> Groups { get; set; }
	}
	
	public class Group
	{
		public string Name { get; set; }
		
		public IEnumerable<string> ColumnNames { get; set; }
		
		public IList<IList<object>> Rows { get; set; }
	}
