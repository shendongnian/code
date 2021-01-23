    public class GeoFeedHub : Hub
    {
    	// Declare dependency on TwitterStream class
    	private readonly TwitterStream _twitterStream;
    
    	// Use constructor injection to get an instance of TwitterStream
    	public GeoFeedHub(TwitterStream _twitterStream)
    	{
    		_twitterStream = _twitterStream;
    	}
    
    	// Clients can call this method, which uses the instance of TwitterStream
    	public async Task SetStreamBounds(double latitude, double longitude)
    	{
    		await _twitterStream.SetStreamBoundsAsync(latitude, longitude);
    	}
    }
    
    
    public class TwitterStream
    {
    	public TwitterStream() 
    	{
    	}
    	
    	public async Task SetStreamBoundsAsync(double latitude, double longitude)
    	{
    		// Do something with Twitter here maybe?
    		await SomeComponent.SetStreamBoundsAsync(latitude, longitude);
    	}
    	
    	// More awesome code here
    }
