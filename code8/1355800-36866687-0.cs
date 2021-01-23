    [DllImport("User32.Dll")]
    public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);
    public static RECT GetClientRect(IntPtr hWnd)
    {
        RECT result;
        GetClientRect1(hWnd, out result);
        RECT appRect = result;
        return result;
    }
