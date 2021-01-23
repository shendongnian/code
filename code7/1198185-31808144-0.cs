    System.Windows.Media.Imaging.BitmapSource bitmapSource =
      System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
      gdiBitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty,
      System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
    System.Windows.Media.Imaging.WriteableBitmap writeableBitmap = new System.Windows.Media.Imaging.WriteableBitmap(bitmapSource);
