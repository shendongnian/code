    public static Bitmap ToBitmap(int[,] image)
    {
        int width = image.GetLength(0);
        int height = image.GetLength(1);
        Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
        BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height),
                                    ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
        int stride = bitmapData.Stride;
        // A dictionary of colors to their index values
        Dictionary<int, int> palette = new Dictionary<int, int>();
        // A flat list of colors
        List<Color> paletteList = new List<Color>();
        unsafe
        {
            byte* address = (byte*)bitmapData.Scan0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Get the color from the Bitmap
                    int color = image[x, y];
                    if (!palette.ContainsKey(color))
                    {
                        // This color isn't in the palette, go ahead and add it
                        palette.Add(color, palette.Count);
                        paletteList.Add(Color.FromArgb(color));
                        if (palette.Count >= 256)
                        {
                            // The palette is too big.  Ideally this function would
                            // dither some pixels so it could handle this condition
                            // but that would make this example overly complicated
                            throw new InvalidOperationException("Too many colors in image");
                        }
                    }
                    // And lookup the index of the color in the palette and
                    // add it to the BitmapData's memory
                    address[stride * y + x] = (byte)palette[color];
                }
            }
        }
        bitmap.UnlockBits(bitmapData);
        // Each time you call Bitmap.Palette it actually returns
        // a Clone of the object, so we need to ask for a cloned
        // copy here.
        var newPalette = bitmap.Palette;
        // For each one of our colors, add it to the palette object
        for (int i = 0; i < paletteList.Count; i++)
        {
            newPalette.Entries[i] = paletteList[i];
        }
        // And since this is a clone, assign it back to the bitmap
        // so it'll take effect.
        bitmap.Palette = newPalette;
        return bitmap;
    }
    public static int[,] ToInteger(Bitmap bitmap)
    {
        if (bitmap.Palette.Entries.Length == 0)
        {
            // This doesn't appear to have a palette, so this operation doesn't
            // make sense
            throw new InvalidOperationException("bitmap is not an indexed bitmap");
        }
        int width = bitmap.Width;
        int height = bitmap.Height;
        int[,] array2D = new int[width, height];
        BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height),
                                                    ImageLockMode.ReadOnly,
                                                    PixelFormat.Format8bppIndexed);
        unsafe
        {
            // Pull out the stride to prevent asking for it many times
            int stride = bitmapData.Stride;
            byte* address = (byte*)bitmapData.Scan0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Lookup the color based off the pixel, and set it's value
                    // to the return array
                    array2D[x, y] = bitmap.Palette.Entries[address[stride * y + x]].ToArgb();
                }
            }
        }
        bitmap.UnlockBits(bitmapData);
        return array2D;
    }
