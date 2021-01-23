    unsafe Color getPixel(Bitmap bmp, int x, int y)
    {
        BitmapData bmData = bmp.LockBits( new Rectangle(0, 0, bmp.Width, bmp.Height),
                            System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
        // not a complete check, but a start on how to use different pixelformats
        int pixWidth = bmp.PixelFormat == PixelFormat.Format24bppRgb ? 3 :
                       bmp.PixelFormat == PixelFormat.Format32bppArgb ? 4 : 4;
        IntPtr scan0 = bmData.Scan0;
        int stride = bmData.Stride;
        byte* p = (byte*)scan0.ToPointer() + y * stride;
        int px = x * pixWidth;
        byte alpha = (byte) (pixWidth == 4 ? p[px + 3] : 255);
        Color color  = Color.FromArgb(alpha , p[px + 2], p[px + 1], p[px + 0]);
        bmp.UnlockBits(bmData);
        return color;
    }
