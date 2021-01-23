    //Should be adjusted for specific use.
	public void postAssync(Message message)
	{
		var totalPending = block1.InputCount + ... + blockn.InputCount;
		if (totalPending > 100)
		{
			Thread.Sleep(200);
            //Note: if allocating huge quantities of memory the Garbage collector may not collect in time. This is the perfect place to force garbage collector to release some memory.
           
		}
        block1.SendAssync(message)
	}
