    //Windows API for resizing the window.
    [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern int SendMessage(IntPtr hWnd, uint Msg, long lParam, long wParam);
    
    [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool ReleaseCapture();
    
    [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool ShowWindow(IntPtr hWnd, int cmdShow);
