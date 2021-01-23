	static void Main(string[] args)
	{
			var debugMode = args.Contains("--debug", StringComparer.InvariantCultureIgnoreCase);
			
			if (!debugMode)
			{
				ServiceBase[] servicesToRun =
				{
					new MyService();
				};
				ServiceBase.Run(servicesToRun);
			}
			else
			{
				var service = new MyService();
				service.StartService(args);
				Console.WriteLine("Service is now running, press enter to stop...");
				Console.ReadLine();
				service.StopService();
			}
		}
	}
