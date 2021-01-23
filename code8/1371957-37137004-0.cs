        public Bitmap ScaleBitmap(Bitmap src, Size NewSize)
        {
            Bitmap bmp = new Bitmap(NewSize.Width, NewSize.Height, src.PixelFormat);
            Graphics g = Graphics.FromImage(src);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(src, new Rectangle(Point.Empty, NewSize), new Rectangle(0, 0, src.Width, src.Height), GraphicsUnit.Pixel);
            g.Dispose();
            return bmp;
        }
