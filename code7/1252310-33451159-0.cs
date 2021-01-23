    public static class Extensions
    {
    	public static void FireAndForget(this Task task)
    	{
    		task.ContinueWith(t => 
    		{
    			// log exceptions
    			t.Exception.Handle((ex) =>
    			{
    				Console.WriteLine(ex.Message);
    				return true;
    			});
    			
    		}, TaskContinuationOptions.OnlyOnFaulted);
    	}
    }
    
    public async Task FailingOperation()
    {
    	await Task.Delay(2000);
    	
    	throw new Exception("Error");
    }	
    
    void Main()
    {
    	FailingOperation().FireAndForget();
    	
    	Console.ReadLine();
    }
