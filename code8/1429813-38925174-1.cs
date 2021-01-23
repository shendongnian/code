    public Bitmap SetGrayscale(Bitmap img)
    {
        LockedBitmap lockedBmp = new LockedBitmap(img.Clone());
        lockedBmp.LockBits(); // lock the bits for faster access
        Color c;
        for (int i = 0; i < lockedBmp.Width; i++)
        {
            for (int j = 0; j < lockedBmp.Height; j++)
            {
                c = lockedBmp.GetPixel(i, j);
                byte gray = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);
                lockedBmp.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
            }
        }
        lockedBmp.UnlockBits(); // remember to release resources
        return lockedBmp.Bitmap; // return the bitmap (you don't need to clone it again, that's already been done).
    }
