	public partial class ScanListItem
	{
		public string SessionId { get; set; }
		public string InstanceId { get; set; }
		public string ClientId { get; set; }
		public string DeviceId { get; set; }
		public Document Document {get;set;}
	}
	
	public class Document
	{
		public string NameOfHolder {get;set;}
		public List<string> Features {get;set;}
        //Other properties here. 
	}
