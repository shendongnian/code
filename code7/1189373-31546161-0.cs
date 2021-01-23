   	public class Reply
	{
		public string comment { get; set; }
		public string username { get; set; }
		public string profile_pic { get; set; }
	}
	public class Details
	{
		public List<Reply> replies { get; set; }
		public string totalreply { get; set; }
	}
	public class RootObject
	{
		public string status { get; set; }
		public string Error { get; set; }
		public string Reason { get; set; }
		public Details details { get; set; }
	}
