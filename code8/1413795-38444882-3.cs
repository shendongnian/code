    // Leave off the .exe when using the process name
    var process = Process.GetProcessesByName("Something").FirstOrDefault(); 
    if (process != null)
    {
        process.Start();
    }
