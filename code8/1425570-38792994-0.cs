	[Serializable()]
	[XmlRoot("POSLog")]
	public class POSLog
	{
		[XmlElement("Transaction")]
		public Transaction[] Transaction { get; set; }
	}	
