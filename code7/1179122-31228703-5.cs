    AutoItX3 au3 = new AutoItX3();
    string processName = "mspaint";
    Process[] processes = Process.GetProcessesByName(processName);
    if (processes.Length == 0) // Process not running
    {
        int processId = au3.Run(@"C:\Windows\System32\mspaint.exe", "", au3.SW_SHOW);
        Process process = Process.GetProcessById(processId);
        IntPtr handle = process.MainWindowHandle;
        BringToFront(handle);
        Thread.Sleep(10000);
        au3.MouseClick("LEFT", 358, 913, 1, -1);
    }
    else // Process running
    {
        BringToFront(processes[0].MainWindowHandle);
        au3.MouseClick("LEFT", 358, 913, 1, -1);
    }
