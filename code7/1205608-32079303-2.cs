    static Bitmap FindDifferentPixels(Bitmap i1, Bitmap i2)
    {
        var result = new Bitmap(i1.Width, i2.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        var ia1 = new BitmapWithAccess(i1, System.Drawing.Imaging.ImageLockMode.ReadOnly);
        var ia2 = new BitmapWithAccess(i2, System.Drawing.Imaging.ImageLockMode.ReadOnly);
        var ra = new BitmapWithAccess(result, System.Drawing.Imaging.ImageLockMode.ReadWrite);
        for (int x = 1;x < i1.Width - 1;++x)
            for (int y = 1;y < i1.Height - 1;++y)
            {
                var different = ia1.GetPixel(x, y) != ia2.GetPixel(x, y);
                ra.SetPixel(x, y, different ? Color.White : Color.FromArgb(0, 0, 0, 0));
            }
        ia1.Release();
        ia2.Release();
        ra.Release();
        return result;
    }
