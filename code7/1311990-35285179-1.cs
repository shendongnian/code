    private static unsafe void To24BppUintAssignment(Bitmap source, Bitmap dest)
    {
        var sourceData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
        var destData = dest.LockBits(new Rectangle(0, 0, dest.Width, dest.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
        uint[] paletteBytes = source.Palette.Entries.Select(ColorToUintRgbRightAligned).ToArray();
        var current = (byte*)sourceData.Scan0.ToPointer();
        var lastPtr = (byte*)(sourceData.Scan0 + sourceData.Width * sourceData.Height).ToPointer();
        var targetPtr = (byte*) destData.Scan0;
        while (current < lastPtr)
        {
            var targetAsUint = ((uint*) targetPtr);
            targetAsUint[0] = paletteBytes[*current++];
            targetPtr += 3;
        }
        uint finalValue = paletteBytes[*current];
        targetPtr[0] = (byte)(finalValue >> 24);
        targetPtr[1] = (byte)(finalValue >> 16);
        targetPtr[2] = (byte)(finalValue >> 8);
            source.UnlockBits(sourceData);
        dest.UnlockBits(destData);
        }
        private static uint ColorToUintRgbRightAligned(Color color)
        {
            return ((uint)color.B) + ((uint)color.G << 8) + ((uint)color.R << 16);
        }
