    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(HandleRef hWnd, [In, Out] ref RECT rect);
    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();
    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
