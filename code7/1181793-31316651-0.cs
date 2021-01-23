    public static Tuple<string, string> GetProcessInfo(IntPtr hwnd)
    {
        uint pid = 0;
        GetWindowThreadProcessId(hwnd, out pid);
        Process proc = Process.GetProcessById((int)pid);
        Tuple<string, string> t = new Tuple<string, string>
        (
             proc.MainModule.FileName,
             proc.ProcessName
        );
        return t;
    }
