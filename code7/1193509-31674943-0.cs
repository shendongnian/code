    public static class ImageSourceGenerator
    {
        private static WriteableBitmap bitmap;
        public static ImageSource FromRawByte(sbyte[] colorData, int width, int height)
        {
            if (colorData == null)
            {
                return null;
            }
            if (bitmap == null || bitmap.PixelWidth != width || bitmap.PixelHeight != height)
            {
                bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgr24, null);
            }
            bitmap.WritePixels(new Int32Rect(0, 0, width, height), colorData, width * 3, 0);
            return bitmap;
        }
    }
