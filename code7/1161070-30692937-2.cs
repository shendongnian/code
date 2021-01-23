    Bitmap shade(Bitmap bmp0, Color hue, int strength)
    {
        int Bpp = 4;
        Bitmap bmp1 = new Bitmap(bmp0.Width, bmp0.Height, bmp0.PixelFormat);
        var bmpData0 = bmp0.LockBits(
                        new Rectangle(0, 0, bmp0.Width, bmp0.Height),
                        ImageLockMode.ReadOnly, bmp0.PixelFormat);
        var bmpData1 = bmp1.LockBits(
                        new Rectangle(0, 0, bmp1.Width, bmp1.Height),
                        ImageLockMode.ReadWrite, bmp1.PixelFormat);
        int len = bmpData0.Height * bmpData0.Stride;
        byte[] data0 = new byte[len];
        byte[] data1 = new byte[len];
        Marshal.Copy(bmpData0.Scan0, data0, 0, len);
        Marshal.Copy(bmpData1.Scan0, data1, 0, len);
        for (int i = 0; i < len; i += Bpp)
        {
          data1[i + 0] = (byte)((data0[i + 0] + hue.B / 10f * strength) / (strength / 10f + 1));
          data1[i + 1] = (byte)((data0[i + 1] + hue.G / 10f * strength) / (strength / 10f + 1));
           data1[i + 2] = (byte)((data0[i + 2] + hue.R / 10f * strength) / (strngth / 10f + 1));
          data1[i + 3] = data0[i + 3];
        }
        Marshal.Copy(data1, 0, bmpData1.Scan0, len);
        bmp0.UnlockBits(bmpData0);
        bmp1.UnlockBits(bmpData1);
        return bmp1;
    }
