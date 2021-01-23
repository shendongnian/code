    public Bitmap ClipToCircle(Bitmap original, PointF center, float radius)
    {
        Bitmap copy = new Bitmap(original);
        using (Graphics g = Graphics.FromImage(copy)) {
            RectangleF r = new RectangleF(center.X - radius, center.Y - radius,
                                          radius * 2, radius * 2);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(r);
            g.SetClip(path)
            g.DrawImage(original, 0, 0);
            return copy;
        }
    }
