            Bitmap bmp = new Bitmap(1280, 960, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            var data = bmp.LockBits(new Rectangle(0, 0, 1280, 960), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            byte* srcBmpData = (byte*)pbyteBitmap.ToPointer();
            byte* dstBmpData = (byte*)data.Scan0.ToPointer();
            for (int buc = 0; buc < 1280 * 960; buc++)
            {
                int currentDestPos = buc * 4;
                dstBmpData[buc] = dstBmpData[buc + 1] = dstBmpData[buc + 2] = srcBmpData[buc];
            
            }
            bmp.UnlockBits(data);
