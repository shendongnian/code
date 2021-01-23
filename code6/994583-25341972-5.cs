    var width = pbgraBitmap.PixelWidth;
    var height = pbgraBitmap.PixelHeight;
    var stride = width * 4;
    var buffer = new byte[stride * height];
    pbgraBitmap.CopyPixels(buffer, stride, 0);
    var targetFormat = System.Drawing.Imaging.PixelFormat.Format32bppPArgb;
    var bitmap = new System.Drawing.Bitmap(width, height, targetFormat);
    var bitmapData = bitmap.LockBits(
        new System.Drawing.Rectangle(0, 0, width, height),
        System.Drawing.Imaging.ImageLockMode.WriteOnly,
        targetFormat);
    CopyBufferWithOpacity(buffer, bitmapData, 0.6);
    bitmap.UnlockBits(bitmapData);
