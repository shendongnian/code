	public class Rootobject
	{
		public string status { get; set; }
		public int responseTime{ get; set; }
		public object[] message{ get; set; }
		public Results Results{ get; set; }
	}
	public class Results
	{
		public Series[] series{ get; set; }
	}
	public class Series
	{
		public string seriesID{ get; set; }
		public Datum[] data{ get; set; }
	}
	public class Datum
	{
		public string year{ get; set; }
		public string period{ get; set; }
		public string periodName{ get; set; }
		public string value{ get; set; }
		public Footnote[] footnotes{ get; set; }
	}
	public class Footnote
	{
	}
