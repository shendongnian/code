    /// <summary>
    /// Destroys an icon and frees any memory the icon occupied.
    /// </summary>
    /// <param name="hIcon">A handle to the icon to be destroyed. The icon must not be in use.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
    /// <remarks>To get extended error information, call GetLastError.</remarks>
    [DllImport("user32.dll", EntryPoint = "DestroyIcon", SetLastError = true)]
    private static extern bool DestroyIcon(IntPtr hIcon);
