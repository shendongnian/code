	public class Details
	{
		public string date { get; set; }
		public string type { get; set; }
		public string message { get; set; }
	}
	public class Context
	{
		public List<List<ContextElement>> context { get; set; }
	}
	public class Trace
	{
		public Details details { get; set; }
		public Context context { get; set; }
	}
	public class RootObject
	{
		public Trace trace { get; set; }
	}
