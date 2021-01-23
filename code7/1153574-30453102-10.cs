    public void Change(Bitmap bmp)
    {
        LockBitmap source = new LockBitmap(bmp);
        source.LockBits();
        Color white = Color.FromArgb(255, 255, 255, 255);
        int minX = int.MaxValue, maxX = int.MinValue,
            minY = int.MaxValue, maxY = int.MinValue;
        // Brute-force scan of the bitmap to find image boundary
        for (int y = 0; y < source.Height; y++)
        {
            for (int x = 0; x < source.Width; x++)
            {
                if (source.GetPixel(x, y) != white)
                {
                    if (x < minX) minX = x;
                    if (x > maxX) maxX = x;
                    if (y < minY) minY = y;
                    if (y > maxY) maxY = y;
                }
            }
        }
        Bitmap newBitmap = new Bitmap(maxX - minx + 1, maxY - minY + 1, bmp.PixelFormat);
        LockBitmap target = new LockBitmap(newBitmap);
        target.LockBits();
        for (int y = 0; y < target.Height; y++)
        {
            for (int x = 0; x < target.Width; x++)
            {
                target.SetPixel(x, y, source.GetPixel(x + minX, y + minY));
            }
        }
        source.UnlockBits();
        target.UnlockBits();
        newBitmap.Save("d:\\result.png");
    }
