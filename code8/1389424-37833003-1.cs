    static void Main(string[] args)
    {
    	while (true)
    	{
    		Thread.Sleep(500);
    		foreach (var process in Process.GetProcesses())
    		{
    			var memoryUsage = new PerformanceCounter("KB Memory Usage", "Memory Usage", process.ProcessName, false);
    			memoryUsage.RawValue = process.WorkingSet64/1024;
    		}
    	}
    }
