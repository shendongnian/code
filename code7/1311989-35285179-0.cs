    static unsafe void To24Bpp(Bitmap source, Bitmap dest)
    {
        var sourceData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly,
            PixelFormat.Format8bppIndexed);
        var destData = dest.LockBits(new Rectangle(0, 0, dest.Width, dest.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
        var paletteBytes = source.Palette.Entries.Select(ColorToUintRgbLeftAligned).ToArray();
        var current = (byte*) sourceData.Scan0.ToPointer();
        var lastPtr = (byte*) (sourceData.Scan0 + sourceData.Width*sourceData.Height).ToPointer();
        var targetPtr = (byte*) destData.Scan0;
        while (current <= lastPtr)
        {
            var value = paletteBytes[*current++];
            targetPtr[0] = (byte) (value >> 24);
            targetPtr[1] = (byte) (value >> 16);
            targetPtr[2] = (byte) (value >> 8);
            targetPtr += 3;
        }
        source.UnlockBits(sourceData);
        dest.UnlockBits(destData);
    }
    static uint ColorToUintRgbLeftAligned(Color color)
    {
        return ((uint) color.B << 24) + ((uint) color.G << 16) + ((uint) color.R << 8);
    }
