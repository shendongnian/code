    public static class BitmapHelper
    {
        public unsafe static BitmapSource CreateSolidBitmap(int width, int height, double dpiX, double dpiY, Color color)
        {
            var bitmap = new WriteableBitmap(width, height, dpiX, dpiY, PixelFormats.Pbgra32, null);
            var format = bitmap.Format;
            int blueIndex, greenIndex, redIndex, alphaIndex;
            int bitsPerPixel, bytesPerPixel;
            if (!TryParsePixelFormat(format, out bitsPerPixel, out bytesPerPixel, out blueIndex, out greenIndex, out redIndex, out alphaIndex))
                return null;
            var byteWidth = bytesPerPixel * width;
            bitmap.Lock();
            try
            {
                var backBuffer = (byte*)bitmap.BackBuffer.ToPointer();
                for (int iRow = 0; iRow < height; iRow++)
                {
                    var row = backBuffer + (iRow * bitmap.BackBufferStride);
                    for (byte* pixel = row, endRow = row + byteWidth; pixel < endRow; pixel += bytesPerPixel)
                    {
                        pixel[blueIndex] = color.B;
                        pixel[greenIndex] = color.G;
                        pixel[redIndex] = color.R;
                        if (alphaIndex >= 0)
                            pixel[alphaIndex] = color.A;
                    }
                }
                bitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
            }
            finally
            {
                bitmap.Unlock();
            }
            return bitmap;
        }
        static int BlueIndex = 0;
        static int GreenIndex = 1;
        static int RedIndex = 2;
        static int AlphaIndex = 3;
        private static bool TryFindColorIndex(PixelFormatChannelMask mask, out int index)
        {
            var maskList = mask.Mask;
            for (int i = 0, count = maskList.Count; i < count; i++)
            {
                if (maskList[i] == 255)
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }
        static bool TryParsePixelFormat(PixelFormat format, out int bitsPerPixel, out int bytesPerPixel, out int blueIndex, out int greenIndex, out int redIndex, out int alphaIndex)
        {
            // Currently only implemented for non-indexed formats with 3 or 4 bytes
            // per color.
            bitsPerPixel = format.BitsPerPixel;
            if ((bitsPerPixel % 8) != 0)
            {
                bytesPerPixel = blueIndex = greenIndex = redIndex = alphaIndex = -1;
                return false;
            }
            bytesPerPixel = bitsPerPixel / 8;
            var masks = format.Masks;
            int maskCount = masks.Count;
            if (maskCount == 3 || maskCount == 4)
            {
                var blueMask = masks[BlueIndex];
                var greenMask = masks[GreenIndex];
                var redMask = masks[RedIndex];
                if (!TryFindColorIndex(blueMask, out blueIndex)
                    || !TryFindColorIndex(greenMask, out greenIndex)
                    || !TryFindColorIndex(redMask, out redIndex))
                {
                    bytesPerPixel = blueIndex = greenIndex = redIndex = alphaIndex = -1;
                    return false;
                }
                if (maskCount == 3)
                {
                    alphaIndex = -1;
                }
                else
                {
                    if (!TryFindColorIndex(masks[AlphaIndex], out alphaIndex))
                        alphaIndex = -1;
                }
                return true;
            }
            bytesPerPixel = blueIndex = greenIndex = redIndex = alphaIndex = -1;
            return false;
        }
    }
