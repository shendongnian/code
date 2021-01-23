    Boolean createdNew;
    var mut = new Mutex(true, Assembly.GetExecutingAssembly().FullName, out createdNew);
    if (!createdNew)
    {
        if (String.IsNullOrEmpty(appName))
            return;
    
        var processName = Process.GetCurrentProcess().ProcessName;
        foreach (var p in Process.GetProcessesByName(processName))
        {
            if (p.MainWindowTitle.Contains(appName))
            {
                if (userVars.SendDebugOutput)
                {
                    //we found one already running...do anything about it?
                }
                return;
            }
        }
    }
