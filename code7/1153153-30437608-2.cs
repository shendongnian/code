    float stretch1X = 1f * pictureBox1.Image.Width / pictureBox1.ClientSize.Width;
    float stretch1Y = 1f * pictureBox1.Image.Height / pictureBox1.ClientSize.Height;
    Point pt = new Point((int)(mDown.X * stretch1X), (int)(mDown.Y * stretch1Y));
    Size sz = new Size((int)((mCurr.X - mDown.X) * stretch1X), 
                       (int)((mCurr.Y - mDown.Y) * stretch1Y));
    Rectangle rSrc = new Rectangle(pt, sz);
    Rectangle rDest= new Rectangle(Point.Empty, sz);
    Bitmap bmp = new Bitmap(sz.Width, sz.Height);
    using (Graphics G = Graphics.FromImage(bmp))
        G.DrawImage(pictureBox1.Image, rDest, rSrc , GraphicsUnit.Pixel);
    pictureBox2.Image = bmp;
