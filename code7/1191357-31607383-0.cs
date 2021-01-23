    [DllImport("gdi32")]
    static extern int DeleteObject(IntPtr o);
    public BitmapSource loadBitmap(System.Drawing.Bitmap source)
    {
        IntPtr ip = source.GetHbitmap();
        BitmapSource bs = null;
        try
        {
            bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                     ip, IntPtr.Zero, Int32Rect.Empty,
                     System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
        }
        finally
        {
            DeleteObject(ip);
        }
    
        bs.Freeze();
        return bs;
    }
