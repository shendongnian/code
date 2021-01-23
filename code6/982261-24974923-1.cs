    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObject);
    private BitmapSource Bitmap2BitmapSource(Bitmap bitmap)
    {
        IntPtr hBitmap = bitmap.GetHbitMap();
        BitmapSource retval;
    
        try
        {
            retval = Imaging.CreateBitmapSourceFromHBitmap(
                         hBitmap,
                         IntPtr.Zero,
                         Int32Rect.Empty,
                         BitmapSizeOptions.FromEmptyOptions());
        }
        finally
        {
            DeleteObject(hBitmap); //Necessary to avoid memory leak.
        }
    
        return retval;
    }
