    void Main()
    {
    	for (var i = 0; i < 100; i++)
    	{
    		Thread.Sleep(100);
    		var j = i;
    		ThreadPool.QueueUserWorkItem((o) => {
    			// In this example, the call is blocking becase of the Result property access.
    			// In a real async method you would be awaiting the result.
    			var result = computation.Get().Result;
    			
    			Console.WriteLine("{0} {1}", j, result);
    		});
    	}
    }
    
    static ParticularSharedComputation computation = new ParticularSharedComputation();
    
    abstract class SharedComputation
    {
    	volatile Task<string> currentWork;
    	object resourceLock = new object();
    	public async Task<string> Get()
    	{
    		Task<string> current;
    		// We are taking a lock here, but all the operations inside a lock are instant.
    		// Actually we are just scheduling a task to run.
    		lock (resourceLock)
    		{
    			if (currentWork == null)
    			{
    				Console.WriteLine("Looks like we have to do the job...");
    				currentWork = Compute();
    				currentWork.ContinueWith(t => {
    					lock (resourceLock)
    						currentWork = null;
    				});
    			}
    			else
    				Console.WriteLine("Someone is already computing. Ok, will wait a bit...");
    			current = currentWork;
    		}
    
    		return await current;
    	}
    
    	protected abstract Task<string> Compute();
    }
    
    class ParticularSharedComputation : SharedComputation
    {
    	protected override async Task<string> Compute()
    	{
    		// This method is thread safe if it accesses only it's instance data,
    		// as the base class allows only one simultaneous entrance for each instance.
    		// Here you can safely access any data, local for the instance of this class.
    		Console.WriteLine("Computing...");
    
    		// Simulate a long computation.
    		await Task.Delay(2000);
    
    		Console.WriteLine("Computed.");
    		return DateTime.Now.ToString();
    	}
    }
