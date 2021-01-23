    // Copying the object references to a new list prevents enumeration changed exceptions.
    foreach (var proc in processors.ToList())
    {
    	if (proc != null && !proc.IsStopped)
    	{
    		// Direct that each object come to a stop
    		proc.StopProcessor();
    	}
    }
    
    // Now, wait for each one to stop.
    Task.WaitAll(processorTasks.Values.ToArray());
    Task.WaitAll(processorMonitorTasks.Values.ToArray());
