    void DrawPolyGradient(Graphics G,  List<cPoint> cPoints, Rectangle bounds)
    {
        int r = 0; int g = 0; int b = 0; int c = cPoints.Count;
        foreach (Color col in cPoints.Select(x => x.col))
        { r += col.R; g += col.G; b += col.B; }
        Color centercolor = Color.FromArgb(r / c, r / c, r / c);
        PathGradientBrush brush = new PathGradientBrush(cPoints.Select(x => x.pt).ToArray());
        brush.CenterPoint = new PointF(bounds.Width / 2, bounds.Height / 2);
        brush.CenterColor = centercolor;
        brush.SurroundColors = cPoints.Select(x => x.col).ToArray();
        G.FillRectangle(brush, bounds);
    }
