    static void Main(string[] args)
    {
	var cmdArgs = new CommandLineArgs();
	if (args.Length > 0 && CommandLine.Parser.Default.ParseArguments(args, cmdArgs))
        {
  		// display the help
        if (cmdArgs.Help)
        {
              Utils.WriteLine(cmdArgs.GetUsage());
              Console.ReadKey();
        }
		
 		// display the console
  		if (!cmdArgs.Console)
        {
              // hide the console window                   
              setConsoleWindowVisibility(false, Console.Title);
        }
       // verify other console parameters and run your test function
	}
	else if (args.Length == 0)
    {
         // no command line args specified
    }
	// other lines ...
    }
