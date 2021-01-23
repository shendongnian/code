        private unsafe void demo(Bitmap bm)
        {
            System.Drawing.Imaging.BitmapData D = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            int stride = Math.Abs(D.Stride);
            byte* pImg = (byte*)D.Scan0.ToPointer();
            for(int y = 0; y < bm.Height; y++)
            {
                byte* pRow = (byte*)(pImg + y * stride);
                for(int x = 0; x < bm.Width; x++)
                {
                    uint b = *pRow++;
                    uint g = *pRow++;
                    uint r = *pRow++;
                    pRow++; // skip alpha
                    // do something with r g b
                }
            }
            bm.UnlockBits(D);
        }
