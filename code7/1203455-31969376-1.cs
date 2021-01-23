        public static Bitmap Trim(string fileName)
        {
            Bitmap bmp = null;
            try
            {
                bmp = Bitmap.FromFile(fileName) as Bitmap;
                if (bmp == null)
                    throw new ArgumentException("The file is not a valid image.");
                if (bmp.PixelFormat != PixelFormat.Format32bppArgb)
                    throw new ArgumentException("The image file is in an invalid format (32bpp ARGB required)");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("The file is not a valid image.", ex);
            }
            BitmapData bmpData = null;
            int minX, minY, maxX, maxY;
            minX = minY = int.MaxValue;
            maxX = maxY = int.MinValue;
            try
            {
                bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                int bytes = bmpData.Stride * bmp.Height;
                int[] pixelData = new int[bmp.Width * bmp.Height];
                System.Runtime.InteropServices.Marshal.Copy(ptr, pixelData, 0, pixelData.Length);
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        Color pixel = Color.FromArgb(pixelData[x + (bmp.Width * y)]);
                        if (pixel.A != 0)
                        {
                            if (x < minX) minX = x;
                            if (x > maxX) maxX = x;
                            if (y < minY) minY = y;
                            if (y > maxY) maxY = y;
                        }
                    }
                }
                pixelData = null;
                Rectangle cutRect = new Rectangle(minX, minY, maxX - minX, maxY - minY);
                bmp.UnlockBits(bmpData);
                return bmp.Clone(cutRect, bmp.PixelFormat);
            }
            finally
            {
            }
        }
