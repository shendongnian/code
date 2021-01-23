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
        byte bpp1 = 4;
        byte bpp2 = 4;
        byte bpp3 = 4;
        if (fmt1 == PixelFormat.Format24bppRgb) bpp1 = 3;
        else if (fmt1 == PixelFormat.Format32bppArgb) bpp1 = 4; else return null;
        if (fmt2 == PixelFormat.Format24bppRgb) bpp2 = 3;
        else if (fmt2 == PixelFormat.Format32bppArgb) bpp2 = 4; else return null;
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
                int index1 = y * bmp1Data.Stride + x * bpp1;
                int index2 = y * bmp2Data.Stride + x * bpp2;
                int index3 = y * bmp3Data.Stride + x * bpp3;
                Color c1, c2;
                if (bpp1 == 4)
                      c1 = Color.FromArgb(data1[index1 + 3], data1[index1 + 2], data1[index1 + 1], data1[index1 + 0]);
                else  c1 = Color.FromArgb(255, data1[index1 + 2], data1[index1 + 1], data1[index1 + 0]);
                if (bpp1 == 4)
                      c2 = Color.FromArgb(data2[index2 + 3], data2[index2 + 2], data2[index2 + 1], data2[index2 + 0]);
                else  c2 = Color.FromArgb(255, data2[index2 + 2], data2[index2 + 1], data2[index2 + 0]);
                Color putColor = (c1 == c2 ? c1 : diffColor);
                data3[index3 + 0] = putColor.B;
                data3[index3 + 1] = putColor.G;
                data3[index3 + 2] = putColor.R;
                data3[index3 + 3] = putColor.A;
            }
        }
        System.Runtime.InteropServices.Marshal.Copy(data3, 0, bmp3Data.Scan0, data3.Length);
        bmp1.UnlockBits(bmp1Data);
        bmp2.UnlockBits(bmp2Data);
        bmp3.UnlockBits(bmp3Data);
        return bmp3;
    }
