    Bitmap bitmap = new Bitmap(150, 150, PixelFormat.Format32bppRgb);
    BitmapData bmData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
    IntPtr pNative = bmData.Scan0;
    Marshal.Copy(image, 0, pNative, image.Length);
    bitmap.UnlockBits(bmData);
    bitmap.Save(path, ImageFormat.Png);
