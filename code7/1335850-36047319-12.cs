    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        Color c1 = Color.FromArgb(66, 77, 88, 222);
        using (Pen pen = new Pen(c1, 50f))
        {
            pen.MiterLimit = pen.MiterLimit / 12;
            pen.LineJoin = LineJoin.Round;
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            foreach (List<Point> points in allPointLists)
                if (points.Count > 1) e.Graphics.DrawLines(pen, points.ToArray());
        }
        Color c2 = Color.FromArgb(66, 33, 111, 222);
        using (Pen pen = new Pen(c2, 50f))
        {
            pen.MiterLimit = pen.MiterLimit / 4;
            pen.LineJoin = LineJoin.Round;
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            if (currentPoints.Count > 1) e.Graphics.DrawLines(pen, currentPoints.ToArray());
        }
    }
