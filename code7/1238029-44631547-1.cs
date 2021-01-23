    public static Bitmap ConvertFromRGBTo8bit(this Bitmap rgbBmp)
    {
        // Copy image to byte Array
        var BoundsRectSrc = new Rectangle(0, 0, rgbBmp.Width, rgbBmp.Height);
        BitmapData bmpDataSrc = rgbBmp.LockBits(BoundsRectSrc, ImageLockMode.WriteOnly, rgbBmp.PixelFormat);
        IntPtr ptrSrc = bmpDataSrc.Scan0;
        int imgSizeSrc = bmpDataSrc.Stride * rgbBmp.Height;
        byte[] rgbValues = new byte[imgSizeSrc];
        Marshal.Copy(ptrSrc, rgbValues, 0, imgSizeSrc);
        // Crearte bitmap with 8 index grayscale
        Bitmap newBmp = new Bitmap(rgbBmp.Width, rgbBmp.Height, PixelFormat.Format8bppIndexed);
        ColorPalette ncp = newBmp.Palette;
        for (int i = 0; i < 256; i++)
            ncp.Entries[i] = Color.FromArgb(255, i, i, i);
        newBmp.Palette = ncp;
        var BoundsRectDst = new Rectangle(0, 0, rgbBmp.Width, rgbBmp.Height);
        BitmapData bmpDataDst = newBmp.LockBits(BoundsRectDst, ImageLockMode.WriteOnly, newBmp.PixelFormat);
        IntPtr ptrDst = bmpDataDst.Scan0;
        int imgSizeDst = bmpDataDst.Stride * newBmp.Height;
        byte[] grayValues = new byte[imgSizeDst];
        // Convert to 8 bit
        if (rgbBmp.PixelFormat == PixelFormat.Format16bppRgb555 || rgbBmp.PixelFormat == PixelFormat.Format16bppRgb565)
            for (int i = 0, j = 0; i < grayValues.Length; i++, j += 2)
                grayValues[i] = (byte)((rgbValues[j] + rgbValues[j + 1]) / 2);
        else if (rgbBmp.PixelFormat == PixelFormat.Format24bppRgb)
            for (int i = 0, j = 0; i < grayValues.Length; i++, j += 3)
                grayValues[i] = (byte)((rgbValues[j] + rgbValues[j + 1] + rgbValues[j + 2]) / 3);
        else if (rgbBmp.PixelFormat == PixelFormat.Format32bppRgb)
            for (int i = 0, j = 0; i < grayValues.Length; i++, j += 4)
                grayValues[i] = (byte)((rgbValues[j] + rgbValues[j + 1] + rgbValues[j + 2] + rgbValues[j + 3]) / 4);
        Marshal.Copy(grayValues, 0, ptrDst, imgSizeDst);
        newBmp.UnlockBits(bmpDataDst);
        rgbBmp.UnlockBits(bmpDataSrc);
        return newBmp;
    }
