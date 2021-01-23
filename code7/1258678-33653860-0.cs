    [DataContract(Name = "Reply")]
    public class Response
    {
    	 [DataMember(Name = "errorCode")]
    	public String errorCode { set; get; }
    	[DataMember(Name = "errorDescription")]
    	public String errorDescription{ set; get; }
    }
