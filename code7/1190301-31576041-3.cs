 	Console.WriteLine("Running the process");
	System.Threading.Thread workerThread = new System.Threading.Thread(MyFunction);
	workerThread.Start();
	Console.WriteLine("Press X to stop");
	do
	{
		while (!Console.KeyAvailable)
		{
			// Do something
		}
	} while (Console.ReadKey(true).Key != ConsoleKey.X);
	workerThread.Abort();
	Console.WriteLine("Stopped");
