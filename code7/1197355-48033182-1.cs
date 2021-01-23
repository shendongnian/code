    public static BitmapSource ToBitmapImage(this System.Drawing.Bitmap image) {
      var hBitmap = image.GetHbitmap();
      var bitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
      DeleteObject(hBitmap);
      return bitmap;
    }
