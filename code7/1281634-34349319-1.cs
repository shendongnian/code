    public static IntPtr GetWindowHandle(string ProcessName)
    {
        Process[] ProcessList = Process.GetProcessesByName(ProcessName);
    
        if (ProcessList.Count() > 0)
            return ProcessList[0].MainWindowHandle;
    
        return IntPtr.Zero;
    }
