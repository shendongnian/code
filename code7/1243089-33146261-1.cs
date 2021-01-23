	private async Task MyMethodAsync()
	{
		try
		{
		   await Task.Run(() =>
		   {
			  // Do some staff
		   });
		   InvokeContinuation();
		}
		catch (Exception e)
		{
			// Log.
		}
	}
