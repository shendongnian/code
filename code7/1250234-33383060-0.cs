    [XmlRoot("tms_msg")]
    public class TmsMsg
    {
    	[XmlElement("transaction")]
    	public Transaction Transaction { get; set; }
    }
    
    public class Transaction
    {
    	[XmlElement("message_string")]
    	public dynamic MessageString { get; set; }
    }
