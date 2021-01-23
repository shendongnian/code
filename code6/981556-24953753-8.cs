        private static Bitmap ResizeBitmapUpto(Bitmap b, int nWidth, int nHeight, System.Drawing.Drawing2D.InterpolationMode interpolationMode)
        {
            int oldWidth = b.Width;
            int oldHeight = b.Height;
            var box = PlaceInside(oldWidth, oldHeight, nWidth, nHeight);
            int actualNewWidth = (int)Math.Max(Math.Round(box.Width), 1);
            int actualNewHeight = (int)Math.Max(Math.Round(box.Height), 1);
            Bitmap result = new Bitmap(actualNewWidth, actualNewHeight);
            using (Graphics g = Graphics.FromImage((System.Drawing.Image)result))
            {
                g.InterpolationMode = interpolationMode;
                g.DrawImage(b, 0, 0, actualNewWidth, actualNewHeight);
            }
            return result;
        }
