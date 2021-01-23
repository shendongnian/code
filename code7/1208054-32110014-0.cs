    [DllImport("user32.dll", SetLastError = true)]
    internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetWindowRect(IntPtr hWnd, ref Rect lpRect);
    [StructLayout(LayoutKind.Sequential)]
    private struct Rect
    {
       public int Left;
       public int Top;
       public int Right;
       public int Bottom;
    }
