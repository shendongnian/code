    //Should be adjusted for specific use.
	public void postAssync(Message message)
	{
		while (totalPending = block1.InputCount + ... + blockn.InputCount> 100)
		{
			Thread.Sleep(200);
            //Note: if allocating huge quantities for of memory for each message the Garbage collector may keep up with the pace. 
            //This is the perfect place to force garbage collector to release memory.
           
		}
        block1.SendAssync(message)
	}
