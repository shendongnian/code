    public class MockTelemetryChannel : ITelemetryChannel
    {
    	public ConcurrentBag<ITelemetry> SentTelemtries = new ConcurrentBag<ITelemetry>();
    	public bool IsFlushed { get; private set; }
    	public bool? DeveloperMode { get; set; }
    	public string EndpointAddress { get; set; }
    
    	public void Send(ITelemetry item)
    	{
    		this.SentTelemtries.Add(item);
    	}
    
    	public void Flush()
    	{
    		this.IsFlushed = true;
    	}
    
    	public void Dispose()
    	{
    
    	}
    }    
