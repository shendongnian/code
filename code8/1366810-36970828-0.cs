    void DrawEllipse(Graphics G, Pen pen, Point center, Size size, float angle)
    {
        int h2 = size.Height / 2;
        int w2 = size.Width / 2;
        Rectangle rect = new Rectangle( new Point(center.X - w2, center.Y - h2), size );
        G.TranslateTransform(center.X, center.Y);
        G.RotateTransform(angle);
        G.TranslateTransform(-center.X, -center.Y);
        G.DrawEllipse(pen, rect);
    }
