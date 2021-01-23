    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        List<Point> points1 = new List<Point>()
        { new Point(300, 100), new Point(500, 300), new Point(400, 500), new Point(200, 300) };
            
        List<Point> points2 = new List<Point>() 
        { new Point(100, 100), new Point(500, 100), new Point(500, 400), new Point(100, 400) };
        e.Graphics.DrawClosedCurve(Pens.Red, points1.ToArray(), 
            (float)(trackBar1.Value / 100f), System.Drawing.Drawing2D.FillMode.Alternate);
        e.Graphics.DrawClosedCurve(Pens.Blue, points2.ToArray(), 
            (float)(trackBar1.Value / 100f), System.Drawing.Drawing2D.FillMode.Alternate);
    }
