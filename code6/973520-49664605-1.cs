      BitmapData BtmpDt = a.LockBits(new Rectangle(0,0,btm.Width,btm.Height),ImageLockMode.ReadWrite,btm.PixelFormat);
      IntPtr pointer = BtmDt.Scan0;
      int size = Math.Abs(BtmDt.Stride)*btm.Height;
      byte[] pixels = new byte[size];
      Marshal.Copy(pointer,pixels,0, size);
      for (int b = 0; b < pixels.Length; b++) {
        pixels[b] = 255;// do something here 
      }
      Marshal.Copy(pixels,0,pointer, size);
      btm.UnlockBits(BtmDt);
