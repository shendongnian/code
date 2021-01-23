	void Main()
	{
		TestMultiThread();
	}
	
	// Define other methods and classes here
	class Job
	{
	    public string Name;
	
	    public List<Job> Children = new List<Job>();
		
	    public void Run(CancellationTokenSource tokenSource)
	    {
	        for(int i = 0; i < 5; i++)
	        {
	            int tid = Thread.CurrentThread.ManagedThreadId;
	            var msg = "JOB " + Name + "  " + tid +"  cnt "+  i;
				
	            Debug.WriteLine(msg);
	            Thread.Sleep(TimeSpan.FromSeconds(1));
				tokenSource.Token.ThrowIfCancellationRequested();
	        }
	
	        Children.AsParallel()
					.ForAll(j => j.Run(tokenSource));
	    }
	}
	
	public void TestMultiThread()
	{
	    var root = new Job();
	    root.Name = "A";
	    root.Children = new List<Job>()
	    {
	        new Job() { Name = "B" },
	        new Job() { Name = "C" },
	    };
		CancellationTokenSource cts = new CancellationTokenSource();
		var t  =  System.Threading
						.Tasks
						.Task
						.Factory.StartNew(()=> root.Run(cts),cts.Token);
	
	    Thread.Sleep(TimeSpan.FromSeconds(7));
	    Debug.WriteLine("Task Cancel requested");
	    cts.Cancel();
		Debug.WriteLine("Task Canceled");
		try
		{
	    	t.Wait(TimeSpan.FromSeconds(5));
		}
		catch(Exception ex)
		{
			//Linqpad famous Dump method
			ex.Dump();
		}
	    Thread.Sleep(TimeSpan.FromSeconds(5));
	}
