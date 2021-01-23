    public static IntPtr GetMainWindowHandle(string ProcessName)
    {
        Process[] ProcessList = Process.GetProcessesByName(ProcessName);
    
        foreach (Process ThisProcess in ProcessList)
        {
            if (ThisProcess.MainWindowHandle != IntPtr.Zero)
            {
                return ThisProcess.MainWindowHandle;
            }
        }
    
        return IntPtr.Zero;
    }
