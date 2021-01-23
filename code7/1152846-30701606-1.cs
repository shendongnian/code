    [DllImport("gdi32.dll")]
    public static extern int GetDeviceCaps(IntPtr hDc, int nIndex);
    
    [DllImport("user32.dll")]
    public static extern IntPtr GetDC(IntPtr hWnd);
    
    [DllImport("user32.dll")]
    public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDc);
    
    public const int LOGPIXELSX = 88;
    public const int LOGPIXELSY = 90;
    
    /// <summary>
    /// Transforms device independent units (1/96 of an inch)
    /// to pixels
    /// </summary>
    /// <param name="unitX">a device independent unit value X</param>
    /// <param name="unitY">a device independent unit value Y</param>
    /// <param name="pixelX">returns the X value in pixels</param>
    /// <param name="pixelY">returns the Y value in pixels</param>
    public void TransformToPixels(double unitX,
                                  double unitY,
                                  out int pixelX,
                                  out int pixelY)
    {
        IntPtr hDc = GetDC(IntPtr.Zero);
        if (hDc != IntPtr.Zero)
        {
            int dpiX = GetDeviceCaps(hDc, LOGPIXELSX);
            int dpiY = GetDeviceCaps(hDc, LOGPIXELSY);
    
            ReleaseDC(IntPtr.Zero, hDc);
    
            pixelX = (int)(((double)dpiX / 96) * unitX);
            pixelY = (int)(((double)dpiY / 96) * unitY);
        }
        else
            throw new ArgumentNullException("Failed to get DC.");
    }
