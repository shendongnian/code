      static BitmapSource FromBITMAP(ref BITMAP bmp)
      {
            Int32Rect rect = new Int32Rect(0, 0, bmp.Width, bmp.Height);
            IntPtr hbitmap = CreateBitmapIndirect(ref bmp);
            if (hbitmap == IntPtr.Zero)
                return null;
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, rect, BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                DeleteObject(hbitmap);
            }
      }
    
      [DllImport("gdi32.dll", SetLastError = true)]
      public static extern IntPtr CreateBitmapIndirect(ref BITMAP lpbm);
    
      [DllImport("gdi32.dll", SetLastError = true)]
      public static extern bool DeleteObject(IntPtr hObject);
