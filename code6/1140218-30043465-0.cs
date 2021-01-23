	static void Main(string[] args)
	{
		IEnumerable<string> e =
			Enumerable
				.Range(1, 100)
				.AsParallel()
				.Select(
					n =>   
						(n % 15 == 0) ? "Fizzbuzz" :
						(n % 3 == 0) ? "Fizz" :
						(n % 5 == 0) ? "buzz" :
						n.ToString())
				.ToList();
		WriteFile(e);
	}
	
    private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();
    private static void WriteFile(IEnumerable<string> text)
    {
		try
		{
			_readWriteLock.EnterWriteLock();
			File.AppendAllLines(@"C:\Users\Desktop\Test.txt", text);
        }
        finally
        {
        	_readWriteLock.ExitWriteLock();
        }
    }
