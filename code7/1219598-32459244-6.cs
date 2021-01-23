       private static bool[] ConvertImageToBoolArayUnsafe(Bitmap maskbuffer)
        {
            bool[] mask = null;
            int w = maskbuffer.Width;
            int h = maskbuffer.Height;
            
            #region unit_test
                //maskbuffer.Save("mask_image_test.bmp");
            #endregion
          
            lock (maskbuffer)
            {
                BitmapData bmpData = maskbuffer.LockBits(new Rectangle(0, 0, w, h),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format8bppIndexed);
                
                int stride = bmpData.Stride;
                unsafe
                {
             
                    byte* pixels = (byte*) bmpData.Scan0;
                
                    mask = new bool[w * h];
                    for (int y = 0; y < h; ++y)
                    {
                        for (int x = 0; x < w; ++x)
                        {
                            int imageIndex = x + (y * stride);
                            byte color = pixels[imageIndex];
                            int maskIndex = x + (y * w);
                            mask[maskIndex] = color != 0;
                        }
                    }
                    
                }
                maskbuffer.UnlockBits(bmpData);
            }
            #region unit_test
               // byte[] boolAsByte = Array.ConvertAll(mask, b => b ? (byte)1 : (byte)0);
              //  Bitmap maskBitmap = GLImageConvertor.ConvertByteBufferToBitmap(boolAsByte, w, h, PixelFormat.Format8bppIndexed);
              //  int numberOfMasked = mask.Count(b => b);
              //  maskBitmap.Save("mask_bool_test" + numberOfMasked + ".bmp");
            //check equality to safe version (as that is correct)
            #endregion
            return mask;
        }
