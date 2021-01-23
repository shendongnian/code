	public static object syncRoot = new object();
	public void X()
	{
		bool acquiredLock = false;
		try
		{
			Monitor.TryEnter(syncRoot, ref wasLockTaken);
			if (acquiredLock)
			{
				// If we're here, the lock was taken.
			}
		}
		finally
		{
			if (acquiredLock)
				Monitor.Exit(syncRoot);
		}
	}
	
