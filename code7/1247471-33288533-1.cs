	// This is the entry point for this service. 
	// This method runs on an SCM thread.
	public static void Main(string[] args)
	{
		if (Environment.UserInteractive && args.Length > 0)
		{
			switch (args[0])
			{
				// Debug the service as a normal app, presumably within Visual Studio.
				case DEBUG:
					ServiceMain DebugService = new ServiceMain();
					DebugService.OnStart(null);
					break;
