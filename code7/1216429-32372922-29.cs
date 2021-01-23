    void stampIntoImage(Point pt)
    {
        Point point =  new Point(pt.X - stamp.Width / 2, pt.Y - stamp.Height / 2);
        using (Bitmap stamped = new Bitmap(stamp.Width, stamp.Height) )
        {
            using (Graphics G = Graphics.FromImage(stamped))
            {
                stamp.SetResolution(stamped.HorizontalResolution, stamped.VerticalResolution);
                G.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                G.DrawImage(pictureBox1.Image, 0, 0, 
                            new Rectangle(point, stamped.Size), GraphicsUnit.Pixel);
                writeAlpha(stamped, stamp);
            }
            using (Graphics GG = Graphics.FromImage(pictureBox1.Image))
            {
                GG.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                GG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                GG.CompositingQuality = 
                   System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                GG.DrawImage(stamped, point);
            }
        }
        pictureBox1.Image = pictureBox1.Image;
    }
