    public const uint SW_SHOW = 5;
     
    ///<summary>
    /// Forces the window to foreground.
    ///</summary>
    ///<hwnd>The HWND.</param>
    public static void ForceWindowToForeground(IntPtr hwnd)
    {
        AttachedThreadInputAction(
            () =>
            {
                BringWindowToTop(hwnd);
                ShowWindow(hwnd, SW_SHOW);
            });
    }
 
