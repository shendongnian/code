    int x = 1;
    int y = 1;
    int w = 2;
    int h = 2;
    Bitmap bmp = new Bitmap(@"path\to\bitmap.bmp");
 
    Rectangle rect = new Rectangle(x, y, w, h);
    System.Drawing.Imaging.BitmapData bmpData =
        bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
        System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    IntPtr ptr = bmpData.Scan0;
    int bytes = 4 * w * h;
    byte[] rgbValues = new byte[bytes];
    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
    bmp.UnlockBits(bmpData);
