	public class Data
	{
		public int id { get; set; }
		public string barcode { get; set; }
		public int nsr { get; set; }
		public int stk_in { get; set; }
		public int stk_out { get; set; }
		public int sales { get; set; }
		public int balance { get; set; }
	}
	
	public class RootObject
	{
		public List<Data> data { get; set; }
	}	
	RootObject objRootObject = JsonConvert.DeserializeObject<RootObject>(json);
	if (objRootObject.data.Count > 0)
	{
		foreach (var item in objRootObject.data)
		{
			Console.WriteLine(item.id);
			Console.WriteLine(item.barcode);
			Console.WriteLine(item.nsr);
		}
	}
