        private void OpenImage(string filename)
        {
            OPEN_IMAGE_FILE(filename);
            ALLOC_MEMORY();
            int width = GET_IMAGE_WIDTH();
            int height = GET_IMAGE_HEIGHT();
            IntPtr buffer = GET_IMAGE_PIXELS();
            int size = width * height * 3;
            byte[] bitmapImageArray = new byte[size];
            Marshal.Copy(buffer, bitmapImageArray, 0, size);
            Bitmap bitmap3 = ConvertImage3(bitmapImageArray, height, width);
        }
        public Bitmap ConvertImage3(byte[] imageData, int height, int width)
        {
            int size = width * height * 3;
            byte[] bitmapImageArray2 = new byte[size];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bitmapImageArray2[(y * width + x) * 3] = imageData[(x * height + y) * 3 + 2];
                    bitmapImageArray2[(y * width + x) * 3 + 1] = imageData[(x * height + y) * 3 + 1];
                    bitmapImageArray2[(y * width + x) * 3 + 2] = imageData[(x * height + y) * 3];
                }
            }
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData bmData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr pNative = bmData.Scan0;
            Marshal.Copy(bitmapImageArray2, 0, pNative, width * height * 3);
            bitmap.UnlockBits(bmData);
            return bitmap;
        }
