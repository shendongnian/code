    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObject);
    public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
    {
        Bitmap bmp = value as Bitmap;
        if (bmp != null)
        {
            IntPtr hBitmap = bmp.GetHbitmap(); 
            var drawable = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                  hBitmap,
                  IntPtr.Zero,
                  Int32Rect.Empty,
                  BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(hBitmap);
            bmp.Dispose();
            return drawable;
        }
        return null;
    }
