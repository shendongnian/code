	for (int i = 0; i < 100; i++)
	{
		tasks.Add(Task.Factory.StartNew(o =>
		{
            int value = (int)o;
 
			Thread.Sleep(1000);
			Console.WriteLine(value.ToString() + "  " + Thread.CurrentThread.ManagedThreadId);
		}, i));
	}
