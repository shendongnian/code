        private static int CalculateProportionalHeight(int oldWidth, int oldHeight, int newWidth)
        {
            if (oldWidth <= 0 || oldHeight <= 0 || newWidth <= 0)
                // For safety.
                return oldHeight;
            double widthFactor = (double)newWidth / (double)oldWidth;
            int newHeight = (int)Math.Round(widthFactor * (double)oldHeight);
            if (newHeight < 1)
                newHeight = 1; // just in case.
            return newHeight;
        }
        private static Bitmap ResizeBitmap(Bitmap b, int nWidth)
        {
            int nHeight = CalculateProportionalHeight(b.Width, b.Height, nWidth);
            Bitmap result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((System.Drawing.Image)result))
                g.DrawImage(b, 0, 0, nWidth, nHeight);
            return result;
        }
