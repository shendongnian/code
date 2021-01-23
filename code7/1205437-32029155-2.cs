    private static unsafe void Draw(Bitmap bmp, Bitmap bmp2, int xPoint, int yPoint, int pixelBytes) {
    
      BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, bmp.PixelFormat);
      BitmapData bmData2 = bmp2.LockBits(new Rectangle(0, 0, bmp2.Width, bmp2.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp2.PixelFormat);
    
      IntPtr scan0 = bmData.Scan0;
      IntPtr scan02 = bmData2.Scan0;
    
      int stride = bmData.Stride;
      int stride2 = bmData2.Stride;
    
      int nWidth = bmp2.Width;
      int nHeight = bmp2.Height;
    
      int sourceX = 0;
      int sourceY = 0;
    
      if (xPoint < 0) {
        sourceX = -xPoint;
        nWidth -= sourceX;
        xPoint = 0;
      }
      if (yPoint < 0) {
        sourceY = -yPoint;
        nHeight -= sourceY;
        yPoint = 0;
      }
      if (xPoint + nWidth > bmp.Width) {
        nWidth = bmp.Width - xPoint;
      }
      if (yPoint + nHeight > bmp.Height) {
        nHeight = bmp.Height - yPoint;
      }
      if (nWidth > 0 && nHeight > 0) {
    
        byte* p = (byte*)scan0.ToPointer();
        p += yPoint * stride + xPoint * pixelBytes;
        byte* p2 = (byte*)scan02.ToPointer();
        p2 += sourceY * stride2 + sourceX * pixelBytes;
        int bytes = nWidth * pixelBytes;
    
        for (int y = 0; y < nHeight; y++) {
          for (int x = 0; x < bytes; x++) {
            p[0] = p2[0];
            p++;
            p2++;
          }
          p += stride - nWidth * pixelBytes;
          p2 += stride2 - nWidth * pixelBytes;
        }
      }
    
      bmp.UnlockBits(bmData);
      bmp2.UnlockBits(bmData2);
    }
