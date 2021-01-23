    List<Point> points = new List<Point>();
    points.Add(new Point(50,50));points.Add(new Point(60,65));points.Add(new Point(40,70));
    points.Add(new Point(50,90));points.Add(new Point(30,95));points.Add(new Point(20,60));
    points.Add(new Point(40,55));
    using (GraphicsPath gp = new GraphicsPath())
    {
        gp.AddClosedCurve(points.ToArray());
        panel1.Region = new Region(gp);
    }
