    private enum DeviceCaps
    {
        /// <summary>
        /// Logical pixels inch in X
        /// </summary>
        LOGPIXELSX = 88,
        /// <summary>
        /// Horizontal width in pixels
        /// </summary>
        HORZRES = 8,
        /// <summary>
        /// Horizontal width of entire desktop in pixels
        /// </summary>
        DESKTOPHORZRES = 118
    }
    /// <summary>
    /// Retrieves device-specific information for the specified device.
    /// </summary>
    /// <param name="hdc">A handle to the DC.</param>
    /// <param name="nIndex">The item to be returned.</param>
    [DllImport("gdi32.dll")]
    private static extern int GetDeviceCaps(IntPtr hdc, DeviceCaps nIndex);
