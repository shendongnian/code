    public static byte[] BitmapToByteArray(Bitmap image)
            {
                byte[] returns = null;
                if (image.PixelFormat == PixelFormat.Format8bppIndexed)
                {
                    BitmapData bitmapData = image.LockBits(
                                                    new Rectangle(0, 0, image.Width, image.Height),
                                                    ImageLockMode.ReadWrite,
                                                    image.PixelFormat);
                    int noOfPixels = image.Width * image.Height;
                    int colorDepth = Bitmap.GetPixelFormatSize(image.PixelFormat);
                    int step = colorDepth / 8;
                    byte[] bytes = new byte[noOfPixels * step];
                    IntPtr address = bitmapData.Scan0;
                    Marshal.Copy(address, bytes, 0, bytes.Length);
                    ////////////////////////////////////////////////
                    ///
                    returns = (byte[])bytes.Clone();
                    ///
                    ////////////////////////////////////////////////
                    Marshal.Copy(bytes, 0, address, bytes.Length);
                    image.UnlockBits(bitmapData);
                }
                else
                {
                    throw new Exception("8bpp indexed image required");
                }
                return returns;
            }
    
            public static Bitmap ByteArray1dToBitmap(byte[] bytes, int width, int height)
            {
                PixelFormat pixelFormat = PixelFormat.Format8bppIndexed;
                Bitmap bitmap = new Bitmap(width, height, pixelFormat);
    
                // Set the palette for gray shades
                ColorPalette pal = bitmap.Palette;
                for (int i = 0; i < pal.Entries.Length; i++)
                {
                    pal.Entries[i] = Color.FromArgb(i, i, i);
                }
                bitmap.Palette = pal;
    
                BitmapData bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, pixelFormat);
                int colorDepth = Bitmap.GetPixelFormatSize(pixelFormat);
                int noOfChannels = colorDepth / 8;
    
                unsafe
                {
                    byte* address = (byte*)bitmapData.Scan0;
                    int area = width * height;
                    int size = area * noOfChannels;
                    for (int i = 0; i < area; i++)
                    {
                        address[i] = bytes[i];//262144 bytes
                    }
                }
    
                //////////////////////////////////////////////////////////////
                bitmap.UnlockBits(bitmapData);
    
                return bitmap;
            }
