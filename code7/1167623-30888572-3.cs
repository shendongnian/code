    // Classes for passing fault information back to client applications
    [DataContract]
    public class DatabaseFault
    {
    	[DataMember]
    	public string DbOperation;
    	[DataMember]
    	public string DbReason;
    	[DataMember]
    	public string DbMessage;
    }
