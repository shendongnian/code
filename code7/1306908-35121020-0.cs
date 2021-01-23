            public static Color GetPixel(Bitmap bmp, int x, int y)
            {
                BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int stride = bitmapData.Stride;
                Color c;
                unsafe
                {
                    Byte* ptr = (byte*)bitmapData.Scan0;
                    int red = ptr[(x * 3) + y * stride];
                    int green = ptr[(x * 3) + y * stride + 1];
                    int blue = ptr[(x * 3) + y * stride + 2];
                    c = Color.FromArgb(red, green, blue);
                }
                bmp.UnlockBits(bitmapData);
                return c;
            }
    
            public static void SetPixel(Bitmap bmp, int x, int y, Color c)
            {
                BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int stride = bitmapData.Stride;
                unsafe
                {
                    Byte* ptr = (byte*)bitmapData.Scan0;
                    ptr[(x * 3) + y * stride] = c.R;
                    ptr[(x * 3) + y * stride + 1] = c.G;
                    ptr[(x * 3) + y * stride + 2] = c.B;
                }
                bmp.UnlockBits(bitmapData);
            }
