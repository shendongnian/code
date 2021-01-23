    using System.Diagnostics;
    
    //get all currently running applications
    var allProcesses = Process.GetProcesses().ToList();
    //filter out the processes that don't match the exe you're trying to launch
    foreach(var process in allProcesses.Where(p => p.Modules[0].FileName.ToLower().EndsWith(ClientModeExecutablePath.ToLower())))
	{
		try
		{	        
			Console.WriteLine("Process: {0} ID: {1}, file:{2}", process.ProcessName, process.Id, process.Modules[0].FileName);
            //wait for the running process to complete
			process.WaitForExit();
		}
		catch (Exception ex)
		{
			Console.WriteLine (ex);
		}
       //now launch your process
       //two threads could still launch the process at the same time after checking for any running processes
       
    }
