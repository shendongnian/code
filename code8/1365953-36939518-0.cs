	public void Main()
	{
		//Your main program
		
		// [Send the POST]
		
		// Now start another thread to wait for the response while we do other stuff
		ThreadPool.QueueUserWorkItem(new WaitCallback(GetResponse));
		
		//Do other stuff
		//...
	}
	private void GetResponse(object state)
	{
		// Check for evidence of POST response in here
	}
