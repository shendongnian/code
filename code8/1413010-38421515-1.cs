    [DataContract]
    public class GroupProvider
    {
    	[DataMember(Name = "group")]
    	public int Group { get; set; }
    	[DataMember]
    	public DataGroupProvider[] data { get; set; }
    }
    
    [DataContract]
    public class DataGroupProvider
    {
    	[DataMember(Name = "count")]
    	public int Count { get; set; }
    	[DataMember(Name = "providerName")]
    	public string ProviderName { get; set; }
    	[DataMember(Name = "providerNo")]
    	public int ProviderNo { get; set; }
    }
