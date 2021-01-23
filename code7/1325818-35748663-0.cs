    class MyReaderWriterLockSlim: ReaderWriterLockSlim
	{
		new public void EnterWriteLock()
		{ base.EnterReadLock(); }
		new public void EnterReadLock()
		{ base.EnterWriteLock(); }
		new public void ExitReadLock()
		{ base.ExitWriteLock(); }
		new public void ExitWriteLock()
		{ base.ExitReadLock(); }
	}
	class Program
	{
		private static void Main(string[] args)
		{
			MyReaderWriterLockSlim myLock=new MyReaderWriterLockSlim();
			myLock.EnterReadLock();
			try
			{
				//do stuff
			}
			finally 
			{ myLock.ExitReadLock(); }
		}
	}
