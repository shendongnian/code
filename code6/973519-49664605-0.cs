      BitmapData BtmpDt = a.LockBits(new Rectangle(0,0,btm.Width,btm.Height),ImageLockMode.ReadWrite,btm.PixelFormat);
      IntPtr pointer = BtmDt.Scan0;
      byte[] pixels = new byte[Math.Abs(BtmDt.Stride)*btm.Height];
      Marshal.Copy(pointer,pixels,0, Math.Abs(BtmDt.Stride) * btm.Height);
      for (int b = 0; b < pixels.Length; b++) {
        // do something 
      }
      Marshal.Copy(pixels,0,pointer, Math.Abs(BtmDt.Stride) * btm.Height);
      btm.UnlockBits(BtmDt);
