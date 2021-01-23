    /// <summary>
    /// Win32 function to get window information
    /// </summary>
    /// <param name="hWnd">Window handle</param>
    /// <param name="nIndex">Information to get</param>
    /// <returns>Required Window Information</returns>
    [DllImport("user32.dll")]
    internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    /// <summary>
    /// Code to get/set Style for window
    /// </summary>
    private const int GWL_STYLE = -16;
    /// <summary>
    /// System menu bit
    /// </summary>
    private const int WS_SYSMENU = 0x80000;
    /// <summary>
    /// Hide close button on window
    /// </summary>
    /// <param name="w">Window to set</param>
    /// <remarks>Actually removes all of system menu from window title bar</remarks>
    public static void HideCloseButton(Window w)
    {
      var hwnd = new WindowInteropHelper(w).Handle;
      NativeMethods.SetWindowLong(hwnd, GWL_STYLE, NativeMethods.GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
    }
    /// <summary>
    /// Show close button on window
    /// </summary>
    /// <param name="w">Window to set</param>
    /// <remarks>Actually shows all of system menu from window title bar</remarks>
    public static void ShowCloseButton(Window w)
    {
      var hwnd = new WindowInteropHelper(w).Handle;
      NativeMethods.SetWindowLong(hwnd, GWL_STYLE, NativeMethods.GetWindowLong(hwnd, GWL_STYLE) | WS_SYSMENU);
    }
