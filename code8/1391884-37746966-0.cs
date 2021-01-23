    // Use ProcessStartInfo class.
	ProcessStartInfo startInfo = new ProcessStartInfo();
	startInfo.CreateNoWindow = false;
	startInfo.UseShellExecute = false;
	startInfo.FileName = "commandName.exe";
	startInfo.WindowStyle = ProcessWindowStyle.Hidden;
	startInfo.Arguments = "Arguments";
	try
	{
	    // Start the process with the info we specified.
	    // Call WaitForExit and then the using-statement will close.
	    using (Process exeProcess = Process.Start(startInfo))
	    {
		exeProcess.WaitForExit();
	    }
	}
	catch
	{
	    // Log error.
	}
