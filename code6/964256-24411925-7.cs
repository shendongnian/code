    public Bitmap getGrayOverlay(Bitmap bmpColor, Bitmap bmpGray)
    {
        Size s1 = bmpColor.Size;
        Size s2 = bmpGray.Size;
        if (s1 != s2) return null;
        Bitmap bmpResult= new Bitmap(s1.Width, s1.Height);
        for (int y = 0; y < s1.Height; y++)
            for (int x = 0; x < s1.Width; x++)
            {
                Color c1 = bmpColor.GetPixel(x, y);
                Color c2 = bmpGray.GetPixel(x, y);
                bmpResult.SetPixel(x, y, Color.FromArgb((int)(255 * c2.GetBrightness()), c1 ) );
            }
        return bmpResult;
    }
