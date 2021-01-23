    // This method converts a 2dim-Array of Ints to a Bitmap
    public static Bitmap convertToImage(int[,] array)
    {
        Bitmap bmp;
        unsafe
        {
            fixed (int* intPtr = &array[0, 0])
            {
                bmp = new Bitmap(5, 7, 4, PixelFormat.Format16bppGrayScale, new IntPtr(intPtr));
            }
        }
        BitmapData bmpData = bmp.LockBits(new Rectangle(new Point(), bmp.Size), ImageLockMode.ReadOnly, PixelFormat.Format16bppGrayScale);
        IntPtr bmpPtr = bmpData.Scan0;
        byte[] dataAsBytes = new byte[bmpData.Stride * bmpData.Height];
        System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, dataAsBytes, 0, dataAsBytes.Length);
        // Here dataAsBytes contains the pixel data of bmp
        return bmp;
    }
