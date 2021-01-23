    void panel1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        double x = a;
        double y = Root(x, 3);
        cos.DrawSystem(e.Graphics);
        points.Add(cos.RelativePoint(new PointF((float)x, (float)y)));
        e.Graphics.DrawLines(Pens.Red, points.ToArray());
    }
