    private BitmapSource Convert(System.Drawing.Bitmap bitmap)
    {
        var bitmapData = bitmap.LockBits(
            new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
            System.Drawing.Imaging.ImageLockMode.ReadOnly,
            bitmap.PixelFormat);
        var bitmapSource = new WriteableBitmap(
            bitmap.Width, bitmap.Height, 96, 96, PixelFormats.Bgr24, null);
        bitmapSource.WritePixels(
            new Int32Rect(0, 0, bitmap.Width, bitmap.Height),
            bitmapData.Scan0,
            bitmapData.Stride * bitmapData.Height,
            bitmapData.Stride);
        bitmap.UnlockBits(bitmapData);
        return bitmapSource;
    }
    private BitmapSource Convert(System.Drawing.Bitmap bitmap)
    {
        var bitmapData = bitmap.LockBits(
            new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
            System.Drawing.Imaging.ImageLockMode.ReadOnly,
            bitmap.PixelFormat);
        var buffer = new byte[bitmapData.Stride * bitmapData.Height];
        Marshal.Copy(bitmapData.Scan0, buffer, 0, bitmapData.Stride * bitmapData.Height);
        bitmap.UnlockBits(bitmapData);
        return BitmapSource.Create(bitmap.Width, bitmap.Height,
            96, 96, PixelFormats.Bgr24, null, buffer, bitmapData.Stride);
    }
