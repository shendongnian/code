    void writeAlpha(Bitmap target, Bitmap source)
    {
       // this method is the bitmaps both are 32bpp and have the same size
        int Bpp = 4;  
        var bmpData0 = target.LockBits(
                        new Rectangle(0, 0, target.Width, target.Height),
                        ImageLockMode.ReadWrite, target.PixelFormat);
        var bmpData1 = source.LockBits(
                        new Rectangle(0, 0, source.Width, source.Height),
                        ImageLockMode.ReadOnly, source.PixelFormat);
        int len = bmpData0.Height * bmpData0.Stride;
        byte[] data0 = new byte[len];
        byte[] data1 = new byte[len];
        Marshal.Copy(bmpData0.Scan0, data0, 0, len);
        Marshal.Copy(bmpData1.Scan0, data1, 0, len);
        for (int i = 0; i < len; i += Bpp)
        {
            int tgtA = data0[i+3];        // opacity
            int srcA = 255 - data1[i+3];  // transparency
            if (srcA > 0) data0[i + 3] = (byte)(tgtA < srcA ? 0 : tgtA - srcA);
        }
        Marshal.Copy(data0, 0, bmpData0.Scan0, len);
        target.UnlockBits(bmpData0);
        source.UnlockBits(bmpData1);
    }
