    // Creates a bitmap that has a single row containing single pixels with the given colors.
    // At most 256 colors.
    public static BitmapSource GetColorsBitmap(IList<Color> colors)
    {
        if (colors == null) throw new ArgumentNullException("colors");
        if (colors.Count > 256) throw new ArgumentOutOfRangeException("colors", "More than 256 colors");
        int size = colors.Count;
        for (int j = colors.Count; j < 256; j++)
        {
            colors.Add(Colors.White);
        }
        var palette = new BitmapPalette(colors);
        byte[] pixels = new byte[size];
        for (int i = 0; i < size; i++)
        {
            pixels[i] = (byte)i;
        }
        var bm = BitmapSource.Create(size, 1, 96, 96, PixelFormats.Indexed8, palette, pixels, 1 * size);
        bm.Freeze();
        return bm;
    }
