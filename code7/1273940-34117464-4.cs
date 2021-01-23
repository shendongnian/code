	public static object syncRoot = new object();
	public static Semaphore semaphore = new Semaphore(1, 1);
	
	public static void Main()
	{
		try
		{
			if (!semaphore.WaitOne(0))
			{
				// If we're here, the lock was taken.
			}
		}
		finally
		{
			semaphore.Release();
		}
	}
