	public class DataObj
	{
		public string isAvial { get; set; }
		public string details { get; set; }
		public string id { get; set; }
		// public DataTable data { get; set; } // if this is the FCL defined DataTable you will not be able to deserialize it without some custom code. Better would be to have a strongly typed custom class 
	}
	var desc = JsonConvert.DeserializeObject<List<DataObj>>(jsonstring);
