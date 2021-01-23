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
        using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
        {
            pixelX = (int)((g.DpiX / 96) * unitX);
            pixelY = (int)((g.DpiY / 96) * unitY);
        }
    
        // alternative:
        // using (Graphics g = Graphics.FromHdc(IntPtr.Zero)) { }
    }
