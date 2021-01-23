    private void TestFunction()
	{
		MutexFactory factory = new MutexFactory("YourMutexId");
		
		for (int i = 0; i < 100; i++)
		{
            // also works for new instances of your program of course
			new Thread(Interlocked).Start(factory);
		}
	}
	private void Interlocked(object obj)
	{
		Guid guid = Guid.NewGuid();
		MutexFactory factory = obj as MutexFactory;
		using (factory.Lock())
		{
			Debug.WriteLine(guid.ToString("N") + " start");
			//Waste Time
			Thread.Sleep(50);
			Debug.WriteLine(guid.ToString("N") + " end");   
		}
	}
