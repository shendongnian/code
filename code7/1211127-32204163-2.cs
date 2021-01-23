      Bitmap bmp = new Bitmap(5, 5, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
      var bitmapData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, bmp.PixelFormat);
      Marshal.Copy(data, 0, bitmapData.Scan0, data.Length);
      bmp.UnlockBits(bitmapData);
      bmp.Save(@"c:\tmp.png");
