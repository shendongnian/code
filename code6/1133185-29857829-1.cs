    private void UpdateLayeredBitmap(Bitmap bitmap)
        {
        // Does this bitmap contain an alpha channel?
        if (bitmap.PixelFormat != System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        {
            //"The bitmap must be 32bpp with alpha-channel."
        }
        // Get device contexts
        IntPtr screenDc = GetDC(IntPtr.Zero);
        IntPtr memDc = CreateCompatibleDC(screenDc);
        IntPtr hBitmap = IntPtr.Zero;
        IntPtr hOldBitmap = IntPtr.Zero;
        try
        {            
            // Get handle to the new bitmap and select it into the current device context
            hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
            hOldBitmap = SelectObject(memDc, hBitmap);
            newLocation = new POINT(this.Location.X, this.Location.Y);
            // Update the window
            UpdateLayeredWindow(Handle, IntPtr.Zero, ref newLocation, ref newSize, memDc, ref sourceLocation, 0, ref blend, ULW_ALPHA);
        }
        catch (Exception e)
        {
            Console.WriteLine("{0} Exception caught.", e);
        }
        if (hBitmap != IntPtr.Zero)
        {
            SelectObject(memDc, hOldBitmap);
            // Remove bitmap resources
            DeleteObject(hBitmap);
        }
        DeleteDC(memDc);
        DeleteDC(screenDc);
    }
