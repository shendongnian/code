        public static Image<Bgra, Byte> Overlay(Image<Bgra, Byte> target, Image<Bgra, Byte> overlay)
        {
            Bitmap bmp = target.Bitmap;
            Graphics gra = Graphics.FromImage(bmp);
            gra.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            gra.DrawImage(overlay.Bitmap, new Point(0, 0));
            return target;
        }
