    [DllImport("USER32.DLL")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);
    public static void BringToFront(int processId)
    {
        Process process = Process.GetProcessById(processId);
        IntPtr handle = process.MainWindowHandle;
        if (handle == IntPtr.Zero)
            return;
        SetForegroundWindow(handle);
    }
