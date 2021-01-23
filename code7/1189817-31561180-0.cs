	public void Algorithm()
	{
	   for (var iteration = 0; iteration < 1000; iteration++)
	   {
			// allow the GC to allocate 4kb
			if (GC.TryStartNoGCRegion(4096, true))
			{
				try
				{
					PerformIteration();
					SendResults();
				}
				finally
				{
					GC.EndNoGCRegion();
				}
			}
		  //Now there is a small time window to perform GC
		  //before results from the server arrive (thats usually sub 0.5sec window)
		  WaitForUpdate();
	   }
	}
	
	
