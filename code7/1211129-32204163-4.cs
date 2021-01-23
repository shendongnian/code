    byte[] data = new byte[] {
      // B    G    R    A     B    G    R    A     B    G    R    A
          0,   0, 255, 255,    0,   0,   0, 255,    0, 255,   0, 255,
          0,   0,   0, 255,    0, 255,   0, 255,  255, 255, 255, 255,
          0, 255,   0, 255,    0,   0,   0, 255,  255,   0,   0, 255
      };
      int width = 3;
      int height = 3;
      Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
      var bitmapData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, bmp.PixelFormat);
      Marshal.Copy(data, 0, bitmapData.Scan0, data.Length);
      bmp.UnlockBits(bitmapData);
      bmp.Save(@"c:\tmp.png");
