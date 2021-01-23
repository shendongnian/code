    lock (initial)
    {
        BitmapData bmData = initial.LockBits(new Rectangle(0, 0, initial.Width, initial.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, initial.PixelFormat);
        // ....
        initial.UnlockBits(bmData);
    }
