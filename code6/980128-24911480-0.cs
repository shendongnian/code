    private const int SRCCOPY = 0x00CC0020;
    private const string CORE_DLL = "coredll.dll";
    private static IntPtr _taskBar;
    private static IntPtr _sipButton;
    private static string _deviceId, _deviceIp;
    private static DateTime _lastUpdateCheck, _startTime;
    [DllImport(CORE_DLL)]
    public static extern int BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);
    [DllImport(CORE_DLL)]
    public static extern bool CeRunAppAtEvent(string appName, int Event);
    [DllImport(CORE_DLL, EntryPoint = "FindWindowW", SetLastError = true)]
    public static extern IntPtr FindWindowCE(string lpClassName, string lpWindowName);
    [DllImport(CORE_DLL)]
    private static extern IntPtr GetDC(IntPtr hwnd);
    [DllImport(CORE_DLL)]
    public static extern bool MessageBeep(int uType);
    [DllImport(CORE_DLL, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
