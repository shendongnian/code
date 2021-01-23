    public class GroupProvider
    {
    	public int group { get; set; }
    	public DataGroupProvider[] data { get; set; }
    }
    
    public class DataGroupProvider
    {
    	public int count { get; set; }
    	public string providerName { get; set; }
    	public int providerNo { get; set; }
    }
