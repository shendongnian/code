    public class Message
	{
		public string status { get; set; }
		public string messageid { get; set; }
		public string gsm { get; set; }
	}
	public class YourRootEntity
	{
		public string type { get; set; }
		public string totalprice { get; set; }
		public string totalgsm { get; set; }
		public string remaincredit { get; set; }
		public List<Message> messages { get; set; }
	}
