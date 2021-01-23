    // Start the application and wait for it to exit.
    var process = Process.Start(applicationPath, commandLineArguments);
    
    process.WaitForExit();
 
    // If the exit code is not 0, the application closed abnormally.
    if (process.ExitCode != 0)
    {
         // restart process   
    }
