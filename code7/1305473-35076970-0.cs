	public class Rootobject
	{
		public bool isSuccess { get; set; }
		public string responseMessage { get; set; }
		public Responsedata responseData { get; set; }
	}
	public class Responsedata
	{
		public string vouchername { get; set; }
		public string vouchercode { get; set; }
		public string vouchervalue { get; set; }
	}
