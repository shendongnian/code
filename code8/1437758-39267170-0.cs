        public static Bitmap NonfftSharpen(Bitmap image, double[,] mask, double strength)
        {
            Bitmap bitmap = (Bitmap)image.Clone();
            if (bitmap != null)
            {
                int width = bitmap.Width;
                int height = bitmap.Height;
                if (mask.GetLength(0) != mask.GetLength(1))
                {
                    throw new Exception("_numericalKernel dimensions must be same");
                }
                // Create sharpening filter.
                int filterSize = mask.GetLength(0);
                
                double[,] filter = (double[,])mask.Clone();
                int channels = sizeof(byte);
                double bias = 0.0; // 1.0 - strength;
                double factor = 1.0; // strength / 16.0;
                byte[,] result = new byte[bitmap.Width, bitmap.Height];
                // Lock image bits for read/write.
                BitmapData bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, width, height),
                                                            ImageLockMode.ReadWrite,
                                                            System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                // Declare an array to hold the bytes of the bitmap.
                int memorySize = bitmapData.Stride * height;
                byte[] memory = new byte[memorySize];
                // Copy the RGB values into the local array.
                Marshal.Copy(bitmapData.Scan0, memory, 0, memorySize);
                int pixel;
                // Fill the color array with the new sharpened color values.
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        double grayShade = 0.0;
                        for (int filterY = 0; filterY < filterSize; filterY++)
                        {
                            
                            for (int filterX = 0; filterX < filterSize; filterX++)
                            {
                                int imageX = (x - filterSize / 2 + filterX + width) % width;
                                int imageY = (y - filterSize / 2 + filterY + height) % height;
                                pixel = imageY * bitmapData.Stride + channels * imageX;
                                grayShade += memory[pixel] * filter[filterX, filterY];
                                
                            }
                            int newPixel = Math.Min(Math.Max((int)(factor * grayShade + bias), 0), 255);
                            result[x, y] = (byte)newPixel;
                        }
                    }
                }
                // Update the image with the sharpened pixels.
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        pixel = y * bitmapData.Stride + channels * x;
                        memory[pixel] = result[x, y];
                    }
                }
                // Copy the values back to the bitmap.
                Marshal.Copy(memory, 0, bitmapData.Scan0, memorySize);
                // Release image bits.
                bitmap.UnlockBits(bitmapData);
                return bitmap;
            }
            else
            {
                throw new Exception("input image can't be null");
            }
        }
