    [DllImport("User32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetCursorPos(ref Point lpPoint);
    public const int MONITOR_DEFAULTTONEAREST = 2;
    [DllImport("User32.dll")]
    public static extern IntPtr MonitorFromPoint(Point pt, UInt32 dwFlags);
    public IntPtr GetCurrentMonitor()
    {
        Point p = new Point(0,0);
        if (!GetCursorPos(ref p))
        {
            // Decide what to do here.
        }
        IntPtr hMonitor = MonitorFromPoint(p, MONITOR_DEFAULTTONEAREST);
        // validate hMonitor
        return hMonitor;
    }
