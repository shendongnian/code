	var csvPath = System.IO.Path.GetTempFileName(); // Use a temporary file
	// ... Create CSV
	try
	{
		var pathToSecondApp = "C:\\SecondAppFolder\\SecondApp.exe";
		var psi = new ProcessStartInfo(pathToSecondApp);
		psi.Arguments = "-file \"" + csvPath + "\""; // command line arguments for the process
		using(var p = Process.Start(psi))
		{
			// Wait for process to complete
			p.WaitForExit();
			// Analyze return code 
			if (p.ExitCode != 0)
				throw new ApplicationException("Error running Second App");
		}
	}
	finally
	{
		// Delete CSV
		System.IO.File.Delete(csvPath);
	}
