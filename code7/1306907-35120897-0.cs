    var bmp = /* open your bitmap */
    // The area you want to work on. In this case the full bitmap
    Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect,
                        System.Drawing.Imaging.ImageLockMode.ReadWrite,
                        bmp.PixelFormat);
    // Obtain a pointer to the data and copy it to a buffer
    IntPtr ptr = bmpData.Scan0;
    var buffer = new byte[Math.Abs(bmpData.Stride) * bmp.Height];
    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
 
    for (int counter = 0; counter < rgbValues.Length; counter += 3)
    {
        // Here you can edit the buffer
    }
    
    // Copy the data back to the bitmap and unlock it
    System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
    bmp.UnlockBits(bmpData);
