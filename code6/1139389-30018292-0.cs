        public Bitmap GetBitmap(int nWidth, int nHeight, int nBpp, byte* DataColor)
        {
            Bitmap BitmapImage = new Bitmap(nWidth, nHeight, PixelFormat.Format24bppRgb);
            BitmapData srcBmpData = BitmapImage.LockBits(new Rectangle(0, 0, BitmapImage.Width, BitmapImage.Height),
                ImageLockMode.ReadWrite, BitmapImage.PixelFormat);
            switch (BitmapImage.PixelFormat)
            {
                case PixelFormat.Format24bppRgb:
                    unsafe
                    {
                        byte* psrcBuffer = (byte*)srcBmpData.Scan0.ToPointer();
                        int nCount = srcBmpData.Width * srcBmpData.Height;
                        int nIndex = 0;
                        for (int y = 0; y < nCount; y++)
                        {
                            psrcBuffer[nIndex++] = DataColor[y];
                            psrcBuffer[nIndex++] = DataColor[y];
                            psrcBuffer[nIndex++] = DataColor[y];
                        }
                    }
                    break;
            }
            BitmapImage.UnlockBits(srcBmpData);
            return BitmapImage;
        }
