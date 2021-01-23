    public voidstring GetProcessInfo(IntPtr hwnd, out string fileName, out string processName{
        uint pid = 0;
        GetWindowThreadProcessId(hwnd, out pid);
        Process proc = Process.GetProcessById((int)pid);
        fileName = proc.MainModule.FileName.ToString();
        processName = proc.ProcessName;
    }
