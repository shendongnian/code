    private Bitmap ByteToImage(int w, int h, byte[] pixels)
    {
        var bmp = new Bitmap(w, h, PixelFormat.Format16bppRgb565);
        byte bpp = 2;
        var BoundsRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
        BitmapData bmpData = bmp.LockBits(BoundsRect,
                                        ImageLockMode.WriteOnly,
                                        bmp.PixelFormat);
        // copy line by line:
        for (int y = 0; y < h; y++ )
            Marshal.Copy(pixels, y * w * bpp, bmpData.Scan0 + bmpData.Stride * y, w * bpp);
        bmp.UnlockBits(bmpData);
        return bmp;
    }
