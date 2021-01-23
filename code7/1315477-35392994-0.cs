            private Bitmap JpegToBitmap(JpegImage jpeg)
            {
                int width  = jpeg.Width;
                int height = jpeg.Height;
    
                // Read the image into the memory buffer 
                int[] raster = new int[height * width];
    
                for(int i = 0; i < height; ++i)
                {
                    byte[] temp = jpeg.GetRow(i).ToBytes();
                             
                    for (int j = 0; j < temp.Length; j += 3)
                    {
                        int offset = i*width + j / 3;
                        raster[offset] = 0;
                        raster[offset] |= (((int)temp[j+2])   << 16);
                        raster[offset] |= (((int)temp[j+1]) <<  8);
                        raster[offset] |= (int)temp[j];
                    }
                }
                
                Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpdata = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                byte[] bits = new byte[bmpdata.Stride * bmpdata.Height];
    
                for (int y = 0; y < bmp.Height; y++)
                {
                    int rasterOffset = y * bmp.Width;
                    int bitsOffset = (bmp.Height - y - 1) * bmpdata.Stride;
    
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        int rgba = raster[rasterOffset++];
                        bits[bitsOffset++] = (byte)((rgba >> 16) & 0xff);
                        bits[bitsOffset++] = (byte)((rgba >> 8) & 0xff);
                        bits[bitsOffset++] = (byte)(rgba & 0xff);
                    }
                }
                System.Runtime.InteropServices.Marshal.Copy(bits, 0, bmpdata.Scan0, bits.Length);
                bmp.UnlockBits(bmpdata);
    
                return bmp;
            }
