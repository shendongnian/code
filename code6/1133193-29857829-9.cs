    [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
    private static extern int BitBlt(
          IntPtr hdcDest,     // handle to destination DC (device context)
          int nXDest,         // x-coord of destination upper-left corner
          int nYDest,         // y-coord of destination upper-left corner
          int nWidth,         // width of destination rectangle
          int nHeight,        // height of destination rectangle
          IntPtr hdcSrc,      // handle to source DC
          int nXSrc,          // x-coordinate of source upper-left corner
          int nYSrc,          // y-coordinate of source upper-left corner
          int dwRop  // raster operation code
          );
    public const int SRCCOPY = 0x00CC0020;
    IntPtr hdcMemTransparent = IntPtr.Zero, hdcMemGreenOpacityX = IntPtr.Zero, 
           hdcMemGreenOpacityY = IntPtr.Zero, hdcMemForm = IntPtr.Zero;
    IntPtr hBitmapTransparent = IntPtr.Zero, hBitmapGreenOpacityX = IntPtr.Zero,
           hBitmapGreenOpacityY = IntPtr.Zero, hBitmapForm = IntPtr.Zero;
    IntPtr hOldBitmapTransparent = IntPtr.Zero, hOldBitmapGreenOpacityX = IntPtr.Zero, 
           hOldBitmapGreenOpacityY = IntPtr.Zero, hOldBitmapForm = IntPtr.Zero;
    Bitmap bitmapTransparent, bitmapGreenOpacityX, bitmapGreenOpacityY, bitmapForm;
    public Form1()
    {
        InitializeComponent();
        this.Location = new Point(200, 200);
        bitmapForm = new Bitmap(500, 500, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        bitmapTransparent = new Bitmap(500, 500, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        bitmapGreenOpacityX = new Bitmap(500, 500, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        bitmapGreenOpacityY = new Bitmap(500, 500, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        Graphics g;
        g = Graphics.FromImage(bitmapTransparent);
        g.Clear(Color.Transparent);
        g.Dispose();
        g = Graphics.FromImage(bitmapGreenOpacityX);
        g.Clear(Color.FromArgb(50, 0, 255, 0));
        g.Dispose();
        g = Graphics.FromImage(bitmapGreenOpacityY);
        g.Clear(Color.FromArgb(180, 0, 255, 0));
        g.Dispose();
        //Create hdc's
        IntPtr screenDc = GetDC(IntPtr.Zero);
        hdcMemForm = CreateCompatibleDC(screenDc);
        hdcMemTransparent = CreateCompatibleDC(screenDc);
        hdcMemGreenOpacityX = CreateCompatibleDC(screenDc);
        hdcMemGreenOpacityY = CreateCompatibleDC(screenDc);
        hBitmapForm = bitmapForm.GetHbitmap(Color.FromArgb(0));
        hOldBitmapForm = SelectObject(hdcMemForm, hBitmapForm);
        hBitmapTransparent = bitmapTransparent.GetHbitmap(Color.FromArgb(0));
        hOldBitmapTransparent = SelectObject(hdcMemTransparent, hBitmapTransparent);
        hBitmapGreenOpacityX = bitmapGreenOpacityX.GetHbitmap(Color.FromArgb(0));
        hOldBitmapGreenOpacityX = SelectObject(hdcMemGreenOpacityX, hBitmapGreenOpacityX);
        hBitmapGreenOpacityY = bitmapGreenOpacityY.GetHbitmap(Color.FromArgb(0));
        hOldBitmapGreenOpacityY = SelectObject(hdcMemGreenOpacityY, hBitmapGreenOpacityY);
        DeleteDC(screenDc);
        
        //copy hdcMemGreenOpacityX to hdcMemForm
        BitBlt(hdcMemForm, 0, 0, 500, 500, hdcMemGreenOpacityX, 0, 0, SRCCOPY);
        blend = new BLENDFUNCTION();
        // Only works with a 32bpp bitmap
        blend.BlendOp = AC_SRC_OVER;
        // Always 0
        blend.BlendFlags = 0;
        // Set to 255 for per-pixel alpha values
        blend.SourceConstantAlpha = 255;
        // Only works when the bitmap contains an alpha channel
        blend.AlphaFormat = AC_SRC_ALPHA;
        newLocation = new POINT(this.Location.X, this.Location.Y);
        //Update the window
        UpdateLayeredWindow(Handle, IntPtr.Zero, ref newLocation, ref newSize, hdcMemForm, ref sourceLocation,
                 0, ref blend, ULW_ALPHA);
    }
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        long start;
        long stop;
        long frequency;
         double elapsedTime;
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            QueryPerformanceFrequency(out frequency);
            QueryPerformanceCounter(out start);
            //copy hdcMemGreenOpacityX to hdcMemForm
            BitBlt(hdcMemForm, 0, 0, 500, 500, hdcMemGreenOpacityX, 0, 0, SRCCOPY);
            //clear the rectangle that we draw with mouse with transparent color
            BitBlt(hdcMemForm, Math.Min(pnt.X, e.X), Math.Min(pnt.Y, e.Y),
                       Math.Abs(pnt.X - e.X), Math.Abs(pnt.Y - e.Y), hdcMemTransparent, 0, 0, SRCCOPY);
            //copy hdcMemGreenOpacityY to hdcMemForm
            BitBlt(hdcMemForm, Math.Min(pnt.X, e.X), Math.Min(pnt.Y, e.Y),
                       Math.Abs(pnt.X - e.X), Math.Abs(pnt.Y - e.Y), hdcMemGreenOpacityY, 0, 0, SRCCOPY);
            newLocation = new POINT(this.Location.X, this.Location.Y);
            //Update the window
            UpdateLayeredWindow(Handle, IntPtr.Zero, ref newLocation, ref newSize, hdcMemForm, ref sourceLocation,
                 0, ref blend, ULW_ALPHA);
            QueryPerformanceCounter(out stop);
            elapsedTime = ((double)(stop - start) * 1000000.0d) / (double)frequency;
            Console.WriteLine("{0} μsec", elapsedTime);
            //GDI ~ 1.2 msec!!
        }
    }
