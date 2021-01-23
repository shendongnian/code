    void Test()
    {
    	string testString = "Added log";
    	var	logStore = new List<string>();
    	ILogger logger = new MyTestableLogger(logStore);
    	
    	logger.ErrorLogging(testString);
    	
    	Assert.That(logStore.Any(log => log==testString));
    }
    
    public interface ILogger
    {
    	void ErrorLogging(string input);
    }
    
    public class MyTestableLogger : ILogger
    {
    	public MyTestableLogger(ICollection<string> logStore)
    	{
    		this.logStore = logStore;
    	}
    
    	private ICollection<string> logStore;
    	
    	public void ErrorLogging(string input)
    	{
    		logStore.Add(input);
    		MyLogger.ErrorLogging(input);
    	}
    }
    
    public static class MyLogger
    {
        public static void ErrorLogging(string input)
        {
    		// Persist input string somewhere
        }
    }
