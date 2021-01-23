            public static void CaptureScreen(double x, double y, double width, double height)
            {
                int ix, iy, iw, ih;
                ix = Convert.ToInt32(x);
                iy = Convert.ToInt32(y);
                iw = Convert.ToInt32(width);
                ih = Convert.ToInt32(height);
                Bitmap image = new Bitmap(iw, ih,
                       System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(image);
                g.CopyFromScreen(ix, iy, ix, iy,
                         new System.Drawing.Size(iw, ih),
                         CopyPixelOperation.SourceCopy);
                // Download Image
                image.Save(FileName, ImageFormat.Png);
           }
