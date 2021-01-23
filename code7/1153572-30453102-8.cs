    public void Change(Bitmap bmp)
    {
        Bitmap newBitmap = new Bitmap(bmp.Width, bmp.Height, bmp.PixelFormat);
        LockBitmap source = new LockBitmap(bmp),
            target = new LockBitmap(newBitmap);
        source.LockBits();
        target.LockBits();
        Color white = Color.FromArgb(255, 255, 255, 255);
        for (int y = 0; y < source.Height; y++)
        {
            for (int x = 0; x < source.Width; x++)
            {
                Color old = source.GetPixel(x, y);
                if (old != white)
                {
                    target.SetPixel(x, y, old);
                }
            }
        }
        source.UnlockBits();
        target.UnlockBits();
        newBitmap.Save("d:\\result.png");
    }
