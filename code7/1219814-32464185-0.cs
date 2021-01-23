    Process current = Process.GetCurrentProcess();
    var processes = Process.GetProcessesByName(current.ProcessName)
                           .Where(p => p.Id != current.Id);
    foreach(var process in processes)
    {
        process.Kill(); 
    }
