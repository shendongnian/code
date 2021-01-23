    public class Record
    {
    	[JsonProperty("id")]
    	public int Id
    	{
    		get;
    		set;
    	}
    
    	[JsonProperty("json")]
    	[JsonConverter(typeof(SpecialJsonConverter))]
    	public string Json
    	{
    		get;
    		set;
    	}
    }
