	ApplicationCommandLine AppCommandLine = new ApplicationCommandLine();
	
	try
	{
        // Parsers and sets the variables in AppCommandLine
	    if (AppCommandLine.ParseCommandLine(args))
	    {
	        // Use the Download option from the command line.
	    	if (AppCommandLine.Download) { 
	    		DataFileDownload();
	    	}
	    	if (AppCommandLine.GenerateMode) { 
	    		GenerateProcessingData();
	    	}
		
			...
			
	    }
	}
	
	catch (Exception e)
	{
		...
	}
