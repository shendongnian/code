    public Bitmap getGrayOverlayLB(Bitmap bmp1, Bitmap bmp2)
    {
        Size s1 = bmp1.Size;
        Size s2 = bmp2.Size;
        if (s1 != s2) return null;
        PixelFormat fmt1 = bmp1.PixelFormat;
        PixelFormat fmt2 = bmp2.PixelFormat;
        PixelFormat fmt = new PixelFormat();
        fmt = PixelFormat.Format32bppArgb;
        Bitmap bmp3 = new Bitmap(s1.Width, s1.Height, fmt);
            
        Rectangle rect = new Rectangle(0, 0, s1.Width, s1.Height);
        BitmapData bmp1Data = bmp1.LockBits(rect, ImageLockMode.ReadOnly, fmt1);
        BitmapData bmp2Data = bmp2.LockBits(rect, ImageLockMode.ReadOnly, fmt2);
        BitmapData bmp3Data = bmp3.LockBits(rect, ImageLockMode.ReadWrite, fmt);
        byte bpp = 4;
        int size1 = bmp1Data.Stride * bmp1Data.Height;
        int size2 = bmp2Data.Stride * bmp2Data.Height;
        int size3 = bmp3Data.Stride * bmp3Data.Height;
        byte[] data1 = new byte[size1];
        byte[] data2 = new byte[size2];
        byte[] data3 = new byte[size3];
        System.Runtime.InteropServices.Marshal.Copy(bmp1Data.Scan0, data1, 0, size1);
        System.Runtime.InteropServices.Marshal.Copy(bmp2Data.Scan0, data2, 0, size2);
        System.Runtime.InteropServices.Marshal.Copy(bmp3Data.Scan0, data3, 0, size3);
        for (int y = 0; y < s1.Height; y++)
        {
            for (int x = 0; x < s1.Width; x++)
            {
                int index = y * bmp3Data.Stride + x * bpp;
                Color c1 = Color.FromArgb(data1[index + 3], data1[index + 2], data1[index + 1], data1[index + 0]);
                Color c2 = Color.FromArgb(data2[index + 3], data2[index + 2], data2[index + 1], data2[index + 0]);
                byte A = (byte)(255 * c2.GetBrightness());
                data3[index + 0] = c1.B;
                data3[index + 1] = c1.G;
                data3[index + 2] = c1.R;
                data3[index + 3] = A;
            }
        }
        System.Runtime.InteropServices.Marshal.Copy(data3, 0, bmp3Data.Scan0, data3.Length);
        bmp1.UnlockBits(bmp1Data);
        bmp2.UnlockBits(bmp2Data);
        bmp3.UnlockBits(bmp3Data);
        return bmp3;
    }
