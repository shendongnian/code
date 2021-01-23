    	public class JsonDto
		{
			public string name { get; set; }
			public Schema[] schema {get; set;}
			public string[][] data { get; set; }
		}
		public class Schema
		{
			public string dataType { get; set; }
			public string colName { get; set; }
			public int idx { get; set; }
		}
