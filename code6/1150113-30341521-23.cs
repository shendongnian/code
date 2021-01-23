    Bitmap Gradient2D(Rectangle r, Color c1, Color c2, Color c3, Color c4)
    {
        List<Color> colors = new List<Color> {  c1, c3, c4, c2 };
        Bitmap bmp = new Bitmap(r.Width, r.Height);
        using (Graphics g = Graphics.FromImage(bmp))
        for (int y = 0; y < r.Height; y++)
        {
            using (PathGradientBrush pgb = new PathGradientBrush(getCorners(r).ToArray()))
            {
                pgb.CenterColor = medianColor(colors);
                pgb.SurroundColors = colors.ToArray();
                g.FillRectangle(pgb, 0, y, r.Width, 1);
            }
        }
        return bmp;
    }
