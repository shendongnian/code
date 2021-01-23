    public void ChangeColor(Bitmap bitmap, Color from, Color to)
    {
        if (Image.GetPixelFormatSize(bitmap.PixelFormat) > 8)
        {
            ChangeColorHiColoredBitmap(bitmap, from, to);
            return;
        }
        int indexFrom = Array.IndexOf(bitmap.Palette.Entries, from);
        if (indexFrom < 0)
            return; // nothing to change
        // we could replace the color in the palette but we want to see an example for manipulating the pixels
        int indexTo = Array.IndexOf(bitmap.Palette.Entries, to);
        if (indexTo < 0)
            return; // destination color not found - you can search for the nearest color if you want
        ChangeColorIndexedBitmap(bitmap, indexFrom, indexTo);
    }
    private unsafe void ChangeColorHiColoredBitmap(Bitmap bitmap, Color from, Color to)
    {
        int rawFrom = from.ToArgb();
        int rawTo = to.ToArgb();
        BitmapData data = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), ImageLockMode.ReadWrite, bitmap.PixelFormat);
        byte* line = (byte*)data.Scan0;
        for (int y = 0; y < data.Height; y++)
        {
            for (int x = 0; x < data.Width; x++)
            {
                switch (data.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        byte* pos = line + x * 3;
                        int c24 = Color.FromArgb(pos[0], pos[1], pos[2]).ToArgb();
                        if (c24 == rawFrom)
                        {
                            pos[0] = (byte)(rawTo & 0xFF);
                            pos[1] = (byte)((rawTo >> 8) & 0xFF);
                            pos[2] = (byte)((rawTo >> 16) & 0xFF);
                        }
                        break;
                    case PixelFormat.Format32bppRgb:
                    case PixelFormat.Format32bppArgb:
                        int c32 = *((int*)line + x);
                        if (c32 == rawFrom)
                            *((int*)line + x) = rawTo;
                        break;
                    default:
                        throw new NotSupportedException(); // of course, you can do the same for other pixelformats, too
                }
            }
            line += data.Stride;
        }
        bitmap.UnlockBits(data);
    }
    private unsafe void ChangeColorIndexedBitmap(Bitmap bitmap, int from, int to)
    {
        int bpp = Image.GetPixelFormatSize(bitmap.PixelFormat);
        if (from < 0 || to < 0 || from >= (1 << bpp) || to >= (1 << bpp))
            throw new ArgumentOutOfRangeException();
        if (from == to)
            return;
        BitmapData data = bitmap.LockBits(
            new Rectangle(Point.Empty, bitmap.Size),
            ImageLockMode.ReadWrite,
            bitmap.PixelFormat);
        byte* line = (byte*)data.Scan0;
        // scanning through the lines
        for (int y = 0; y < data.Height; y++)
        {
            // scanning through the pixels within the line
            for (int x = 0; x < data.Width; x++)
            {
                switch (bpp)
                {
                    case 8:
                        if (line[x] == from)
                            line[x] = (byte)to;
                        break;
                    case 4:
                        // First pixel is the high nibble. From and To indices are 0..16
                        byte nibbles = line[x / 2];
                        if ((x & 1) == 0 ? nibbles >> 4 == from : (nibbles & 0x0F) == from)
                        {
                            if ((x & 1) == 0)
                            {
                                nibbles &= 0x0F;
                                nibbles |= (byte)(to << 4);
                            }
                            else
                            {
                                nibbles &= 0xF0;
                                nibbles |= (byte)to;
                            }
                            line[x / 2] = nibbles;
                        }
                        break;
                    case 1:
                        // First pixel is MSB. From and To are 0 or 1.
                        int pos = x / 8;
                        byte mask = (byte)(128 >> (x & 7));
                        if (to == 0)
                            line[pos] &= (byte)~mask;
                        else
                            line[pos] |= mask;
                        break;
                }
            }
            line += data.Stride;
        }
        bitmap.UnlockBits(data);
    }
