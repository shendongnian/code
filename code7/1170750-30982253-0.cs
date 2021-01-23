	int openThread = 0;
	ConcurrentQueue<Type> queue = new ConcurrentQueue<Type>();
	foreach (var sp in lstSps)
	{
		Thread worker = new Thread(() =>
            {
                Interlocked.Increment(ref openThread);
                if(sp.TimeToRun() && sp.HasResult)
				{
					queue.add(sp);
				}
                Interlocked.Decrement(ref openThread);
            }) {Priority = ThreadPriority.AboveNormal, IsBackground = false};
            worker.Start();
	}
	// Wait for all thread to be finnished
	while(openThread > 0)
	{
		Thread.Sleep(500);
	}
	
	// And here move sp from queue to lstSpsToSend
	
	while (lstSpsToSend.Count > 0)
	{
		//Take the first watchdog in list and then remove it
		Sp sp;
		lock (lstSpsToSend)
		{
			sp = lstSpsToSend[0];
			lstSpsToSend.RemoveAt(0);
		}
		try
		{
			//Send the results
		}
		catch (Exception e)
		{
			Thread.Sleep(30000);
		}
	}
	
