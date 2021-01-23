    public static void SaveGif(string fileName, Image image)
    {
        int bpp = Image.GetPixelFormatSize(image.PixelFormat);
        if (bpp == 8)
        {
            image.Save(fileName, ImageFormat.Gif);
            return;
        }
        // 1/4 bpp or high color image: auto convert, and generating palette with transparent color
        // 1 and 4 bpp images are need to be converted, too; otherwise, gif encoder encodes the image from 32 bpp image resulting 256 color, no transparency
        if (bpp < 8)
        {
            using (Image image8Bpp = ConvertPixelFormat(image, PixelFormat.Format8bppIndexed, null))
            {
                image8Bpp.Save(fileName, ImageFormat.Gif);
                return;
            }
        }
        // 32 bpp bitmap with up to 256 colors (multipage image frame or icon): obtaining the correct colors
        // Converting always to 8 bpp pixel format; otherwise, gif encoder would convert it to 32 bpp first. With 8 bpp, gif encoder will preserve transparency and will save compact palette
        Color[] palette = GetColors((Bitmap)image, 256);
        using (Image imageIndexed = ConvertPixelFormat(image, PixelFormat.Format8bppIndexed, palette))
        {
            imageIndexed.Save(fileName, ImageFormat.Gif);
        }
    }
    // TODO: Use some quantizer
    private static Color[] GetColors(Bitmap bitmap, int maxColors)
    {
        if (bitmap == null)
            throw new ArgumentNullException("bitmap");
        if (maxColors < 0)
            throw new ArgumentOutOfRangeException("maxColors");
        HashSet<int> colors = new HashSet<int>();
        PixelFormat pixelFormat = bitmap.PixelFormat;
        if (Image.GetPixelFormatSize(pixelFormat) <= 8)
            return bitmap.Palette.Entries;
        // 32 bpp source: the performant variant
        if (pixelFormat == PixelFormat.Format32bppRgb ||
            pixelFormat == PixelFormat.Format32bppArgb ||
            pixelFormat == PixelFormat.Format32bppPArgb)
        {
            BitmapData data = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), ImageLockMode.ReadOnly, pixelFormat);
            try
            {
                unsafe
                {
                    byte* line = (byte*)data.Scan0;
                    for (int y = 0; y < data.Height; y++)
                    {
                        for (int x = 0; x < data.Width; x++)
                        {
                            int c = ((int*)line)[x];
                            // if alpha is 0, adding the transparent color
                            if ((c >> 24) == 0)
                                c = 0xFFFFFF;
                            if (colors.Contains(c))
                                continue;
                            colors.Add(c);
                            if (colors.Count == maxColors)
                                return colors.Select(Color.FromArgb).ToArray();
                        }
                        line += data.Stride;
                    }
                }
            }
            finally
            {
                bitmap.UnlockBits(data);
            }
        }
        else
        {
            // fallback: getpixel
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    int c = bitmap.GetPixel(x, y).ToArgb();
                    if (colors.Contains(c))
                        continue;
                    colors.Add(c);
                    if (colors.Count == maxColors)
                        return colors.Select(Color.FromArgb).ToArray();
                }
            }
        }
        return colors.Select(Color.FromArgb).ToArray();
    }
    private static Image ConvertPixelFormat(Image image, PixelFormat newPixelFormat, Color[] palette)
    {
        if (image == null)
            throw new ArgumentNullException("image");
        PixelFormat sourcePixelFormat = image.PixelFormat;
        int bpp = Image.GetPixelFormatSize(newPixelFormat);
        if (newPixelFormat == PixelFormat.Format16bppArgb1555 || newPixelFormat == PixelFormat.Format16bppGrayScale)
            throw new NotSupportedException("This pixel format is not supported by GDI+");
        Bitmap result;
        // non-indexed target image (transparency preserved automatically)
        if (bpp > 8)
        {
            result = new Bitmap(image.Width, image.Height, newPixelFormat);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(image, 0, 0, image.Width, image.Height);
            }
            return result;
        }
        int transparentIndex;
        Bitmap bmp;
        // indexed colors: using GDI+ natively
        RGBQUAD[] targetPalette = new RGBQUAD[256];
        int colorCount = InitPalette(targetPalette, bpp, (image is Bitmap) ? image.Palette : null, palette, out transparentIndex);
        BITMAPINFO bmi = new BITMAPINFO();
        bmi.icHeader.biSize = (uint)Marshal.SizeOf(typeof(BITMAPINFOHEADER));
        bmi.icHeader.biWidth = image.Width;
        bmi.icHeader.biHeight = image.Height;
        bmi.icHeader.biPlanes = 1;
        bmi.icHeader.biBitCount = (ushort)bpp;
        bmi.icHeader.biCompression = BI_RGB;
        bmi.icHeader.biSizeImage = (uint)(((image.Width + 7) & 0xFFFFFFF8) * image.Height / (8 / bpp));
        bmi.icHeader.biXPelsPerMeter = 0;
        bmi.icHeader.biYPelsPerMeter = 0;
        bmi.icHeader.biClrUsed = (uint)colorCount;
        bmi.icHeader.biClrImportant = (uint)colorCount;
        bmi.icColors = targetPalette;
        bmp = (image as Bitmap) ?? new Bitmap(image);
        // Creating the indexed bitmap
        IntPtr bits;
        IntPtr hbmResult = CreateDIBSection(IntPtr.Zero, ref bmi, DIB_RGB_COLORS, out bits, IntPtr.Zero, 0);
        // Obtaining screen DC
        IntPtr dcScreen = GetDC(IntPtr.Zero);
        // DC for the original hbitmap
        IntPtr hbmSource = bmp.GetHbitmap();
        IntPtr dcSource = CreateCompatibleDC(dcScreen);
        SelectObject(dcSource, hbmSource);
        // DC for the indexed hbitmap
        IntPtr dcTarget = CreateCompatibleDC(dcScreen);
        SelectObject(dcTarget, hbmResult);
        // Copy content
        BitBlt(dcTarget, 0, 0, image.Width, image.Height, dcSource, 0, 0, 0x00CC0020 /*TernaryRasterOperations.SRCCOPY*/);
        // obtaining result
        result = Image.FromHbitmap(hbmResult);
        result.SetResolution(image.HorizontalResolution, image.VerticalResolution);
        // cleanup
        DeleteDC(dcSource);
        DeleteDC(dcTarget);
        ReleaseDC(IntPtr.Zero, dcScreen);
        DeleteObject(hbmSource);
        DeleteObject(hbmResult);
        ColorPalette resultPalette = result.Palette;
        bool resetPalette = false;
        // restoring transparency
        if (transparentIndex >= 0)
        {
            // updating palette if transparent color is not actually transparent
            if (resultPalette.Entries[transparentIndex].A != 0)
            {
                resultPalette.Entries[transparentIndex] = Color.Transparent;
                resetPalette = true;
            }
            ToIndexedTransparentByArgb(result, bmp, transparentIndex);
        }
        if (resetPalette)
            result.Palette = resultPalette;
        if (!ReferenceEquals(bmp, image))
            bmp.Dispose();
        return result;
    }
    private static int InitPalette(RGBQUAD[] targetPalette, int bpp, ColorPalette originalPalette, Color[] desiredPalette, out int transparentIndex)
    {
        int maxColors = 1 << bpp;
        // using desired palette
        Color[] sourcePalette = desiredPalette;
        // or, using original palette if it has fewer or the same amount of colors as requested
        if (sourcePalette == null && originalPalette != null && originalPalette.Entries.Length > 0 && originalPalette.Entries.Length <= maxColors)
            sourcePalette = originalPalette.Entries;
        // or, using default system palette
        if (sourcePalette == null)
        {
            using (Bitmap bmpReference = new Bitmap(1, 1, GetPixelFormat(bpp)))
            {
                sourcePalette = bmpReference.Palette.Entries;
            }
        }
        // it is ignored if source has too few colors (rest of the entries will be black)
        transparentIndex = -1;
        bool hasBlack = false;
        int colorCount = Math.Min(maxColors, sourcePalette.Length);
        for (int i = 0; i < colorCount; i++)
        {
            targetPalette[i] = new RGBQUAD(sourcePalette[i]);
            if (transparentIndex == -1 && sourcePalette[i].A == 0)
                transparentIndex = i;
            if (!hasBlack && (sourcePalette[i].ToArgb() & 0xFFFFFF) == 0)
                hasBlack = true;
        }
        // if transparent index is 0, relocating it and setting transparent index to 1
        if (transparentIndex == 0)
        {
            targetPalette[0] = targetPalette[1];
            transparentIndex = 1;
        }
        // otherwise, setting the color of transparent index the same as the previous color, so it will not be used during the conversion
        else if (transparentIndex != -1)
        {
            targetPalette[transparentIndex] = targetPalette[transparentIndex - 1];
        }
        // if black color is not found in palette, counting 1 extra colors because it can be used in conversion
        if (colorCount < maxColors && !hasBlack)
            colorCount++;
        return colorCount;
    }
    private unsafe static void ToIndexedTransparentByArgb(Bitmap target, Bitmap source, int transparentIndex)
    {
        int sourceBpp = Image.GetPixelFormatSize(source.PixelFormat);
        int targetBpp = Image.GetPixelFormatSize(target.PixelFormat);
        BitmapData dataTarget = target.LockBits(new Rectangle(Point.Empty, target.Size), ImageLockMode.ReadWrite, target.PixelFormat);
        BitmapData dataSource = source.LockBits(new Rectangle(Point.Empty, source.Size), ImageLockMode.ReadOnly, source.PixelFormat);
        try
        {
            byte* lineSource = (byte*)dataSource.Scan0;
            byte* lineTarget = (byte*)dataTarget.Scan0;
            bool is32Bpp = sourceBpp == 32;
            // scanning through the lines
            for (int y = 0; y < dataSource.Height; y++)
            {
                // scanning through the pixels within the line
                for (int x = 0; x < dataSource.Width; x++)
                {
                    // testing if pixel is transparent (applies both argb and pargb)
                    if (is32Bpp && ((uint*)lineSource)[x] >> 24 == 0
                        || !is32Bpp && ((ulong*)lineSource)[x] >> 48 == 0UL)
                    {
                        switch (targetBpp)
                        {
                            case 8:
                                lineTarget[x] = (byte)transparentIndex;
                                break;
                            case 4:
                                // First pixel is the high nibble
                                int pos = x >> 1;
                                byte nibbles = lineTarget[pos];
                                if ((x & 1) == 0)
                                {
                                    nibbles &= 0x0F;
                                    nibbles |= (byte)(transparentIndex << 4);
                                }
                                else
                                {
                                    nibbles &= 0xF0;
                                    nibbles |= (byte)transparentIndex;
                                }
                                lineTarget[pos] = nibbles;
                                break;
                            case 1:
                                // First pixel is MSB.
                                pos = x >> 3;
                                byte mask = (byte)(128 >> (x & 7));
                                if (transparentIndex == 0)
                                    lineTarget[pos] &= (byte)~mask;
                                else
                                    lineTarget[pos] |= mask;
                                break;
                        }
                    }
                }
                lineSource += dataSource.Stride;
                lineTarget += dataTarget.Stride;
            }
        }
        finally
        {
            target.UnlockBits(dataTarget);
            source.UnlockBits(dataSource);
        }
    }
    private static PixelFormat GetPixelFormat(int bpp)
    {
        switch (bpp)
        {
            case 1:
                return PixelFormat.Format1bppIndexed;
            case 4:
                return PixelFormat.Format4bppIndexed;
            case 8:
                return PixelFormat.Format8bppIndexed;
            case 16:
                return PixelFormat.Format16bppRgb565;
            case 24:
                return PixelFormat.Format24bppRgb;
            case 32:
                return PixelFormat.Format32bppArgb;
            case 48:
                return PixelFormat.Format48bppRgb;
            case 64:
                return PixelFormat.Format64bppArgb;
            default:
                throw new ArgumentOutOfRangeException("bpp");
        }
    }
