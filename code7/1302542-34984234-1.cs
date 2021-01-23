        Rectangle rect = new Rectangle(0, 0, b1.Width, b1.Height);
        BitmapData data1
            = b1.LockBits(rect, ImageLockMode.ReadOnly, b1.PixelFormat);
        BitmapData data2
            = b2.LockBits(rect, ImageLockMode.ReadOnly, b1.PixelFormat);
