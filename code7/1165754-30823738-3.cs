    private void Form1_Click(object sender, EventArgs e)
    {
        Invalidate();
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        int cx = R.Next(300) + 150;
        int cy = R.Next(300) + 140;
        int r = R.Next(300) + 100;
        float m = R.Next(300)/100f;
        int c = R.Next(50) - 25;
        List<PointF> points = Intersections(new PointF(cx, cy), r, m, c);
        List<PointF> points = Intersections(new PointF(cx, cy), r, m, c);
        int x0 = 0;    int x1 = ClientSize.Width;
        int y0 = c;    int y1 = (int)(x1 * m + c);
        if (float.IsPositiveInfinity(m))
           { x0 = c; x1 = c;  y0 = 0; y1 = ClientSize.Height; }
        e.Graphics.DrawEllipse(Pens.Blue, cx - r, cy - r, r + r, r + r);
        e.Graphics.DrawLine(Pens.Green, x0, y0, x1, y1);
        e.Graphics.FillEllipse(Brushes.Blue, cx - 4, cy - 4, 8, 8);
        foreach (PointF pt in points)
            e.Graphics.FillEllipse(Brushes.Red, pt.X - 4, pt.Y - 4, 8, 8 );
        Text = points.Count + "";
    }
