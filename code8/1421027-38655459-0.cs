        private unsafe void DrawImage(Bitmap bmp1)
        {
            BitmapData bmData = bmp1.LockBits(new Rectangle(0, 0, bmp1.Width, bmp1.Height), 
                                              System.Drawing.Imaging.ImageLockMode.ReadWrite, 
                                bmp1.PixelFormat);
            // this is only a rather incomplete test, of course:
            int pixWidth = bmp1.PixelFormat == PixelFormat.Format24bppRgb ? 3 :
                       bmp1.PixelFormat == PixelFormat.Format32bppArgb ? 4 : 4;
            IntPtr scan0 = bmData.Scan0;
            int stride = bmData.Stride;
            int x0 = 100;
            int y0 = 100;
            int x1 = 200;
            int y1 = 300;
            for (int y = y0; y < y1; y++)
            {
                byte* p = (byte*)scan0.ToPointer();
                p += y * stride ;
                for (int x = x0; x < x1; x++)
                {
                    int px = x * pixWidth;
                    p[px + 0] = 0;   //blue
                    p[px + 1] = 120; //green
                    p[px + 2] = 255; //red   
                }
            }
            bmp1.UnlockBits(bmData);
        }
    }
