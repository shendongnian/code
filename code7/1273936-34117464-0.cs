	public static object syncRoot = new object();
	public void X()
	{
		if (!Monitor.TryEnter(syncRoot))
		{
			// If we're here, the lock was taken.
		}
	}
	
