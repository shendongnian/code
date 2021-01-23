    static void Main(string[] args)
    {
		string callingApplication = "None";
		if (args.Length != 0)
		{
			callingApplication = args[0];
		}
		
		int pId = Process.GetCurrentProcess().Id;
		PipeServer.StartPipeServer(pId, callingApplication);
		
		// do things
		
		PipeServer.StopPipeServer();
    }
