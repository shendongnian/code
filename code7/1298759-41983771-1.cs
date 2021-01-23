    public string getActiveWindowName()
    {
        try
        {
            var activatedHandle = GetForegroundWindow();
            Process[] processes = Process.GetProcesses();
            foreach (Process clsProcess in processes)
            {
                if(activatedHandle == clsProcess.MainWindowHandle)
                {
                    string processName = clsProcess.ProcessName;
                    return processName;
                }
            }
        }
        catch { }
        return null;
    }
    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    private static extern IntPtr GetForegroundWindow();
