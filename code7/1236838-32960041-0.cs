    public abstract class IMyDataType<T>
    {
        protected virtual T Data { get; set; }
    	...
    	[JsonProperty("Value")]
    	private T AlternateData
    	{
    		get { return Data; }
    	}
    }
