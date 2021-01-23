     public static bool[] ConvertImageToBoolAray(Bitmap maskbuffer)
        {
            bool[] mask = null;
            int w = maskbuffer.Width;
            int h = maskbuffer.Height;
            #region unit_test
            //maskbuffer.Save("mask_image_test.bmp");
            #endregion
            lock (maskbuffer)
            {
                int numPixels = w * h;
                mask = new bool[numPixels];
                for (int y = 0; y < maskbuffer.Height; ++y)
                {
                    for (int x = 0; x < maskbuffer.Width; ++x)
                    {
                        Color color = maskbuffer.GetPixel(x, y);
                        int index = x + (y*maskbuffer.Width);
                        mask[index] = color.A != 0;
                    }
                }
            }
            #region unit_test
            //byte[] boolAsByte = Array.ConvertAll(mask, b => b ? (byte)1 : (byte)0);
           // Bitmap maskBitmap = GLImageConvertor.ConvertByteBufferToBitmap(boolAsByte, w, h, PixelFormat.Format8bppIndexed);
           // int numberOfMasked = mask.Count(b => b);
           // maskBitmap.Save("mask_bool_test" + numberOfMasked + ".bmp");
            #endregion
            return mask;
        }
