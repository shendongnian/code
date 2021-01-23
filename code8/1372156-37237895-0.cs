    public byte[] ImportBitmap(Bitmap bitmap)
    {
        int width  = bitmap.Width, height = bitmap.Height;
        var bmpArea = new Rectangle(0, 0, width, height);
        var bmpData = bitmap.LockBits(bmpArea, ImageLockMode.ReadWrite, PixelFormat.Format16bppRgb555);
        var data = new byte[bmpData.Stride * Height];
        Marshal.Copy(bmpData.Scan0, data, 0, data.Length);
        bitmap.UnlockBits(bmpData);
        bitmap.Dispose(); // bitmap is no longer required
        var destination = new List<byte>();
        int leapPoint = width * 2;
        for (int i = 0; i < data.Length; i++)
        {
            if (width % 2 != 0)
            {
                // Skip at some point
                if (i == leapPoint)
                {
                    // Skip 2 bytes since it's 16 bit pixel
                    i += 1;
                    leapPoint += (width * 2) + 2;
                    continue;
                }
            }
            destination.Add(data[i]);
        }
        return destination.ToArray();
    }
