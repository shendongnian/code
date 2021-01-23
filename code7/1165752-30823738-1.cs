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
        m = 0; c = 100;
        List<PointF> points = Intersections(new PointF(cx, cy), r, m, c);
        e.Graphics.DrawEllipse(Pens.Blue, cx - r, cy - r, r + r, r + r);
        e.Graphics.DrawLine(Pens.Green, 0, c, ClientSize.Width, m * ClientSize.Width + c);
        e.Graphics.FillEllipse(Brushes.Blue, cx - 4, cy - 4, 8, 8);
        foreach (PointF pt in points)
            e.Graphics.FillEllipse(Brushes.Red, pt.X - 4, pt.Y - 4, 8, 8 );
        Text = points.Count + " intersections";
    }
