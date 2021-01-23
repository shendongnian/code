    private void button7_Click(object sender, EventArgs e)
    {
        chart1.Series.Clear();        chart1.Series.Add("S1");
        chart1.Series.Add("S2");      chart1.Series.Add("S3");
        List<Point> points = new List<Point>();
        points.Add(new Point(1,2));   points.Add(new Point(2,5));
        points.Add(new Point(3,8));   points.Add(new Point(4,6));
        points.Add(new Point(5,4));   points.Add(new Point(6,2));
        points.Add(new Point(7,4));
        chart1.Series[0].ChartType = SeriesChartType.Line;
        chart1.Series[1].ChartType = SeriesChartType.Point;
        chart1.Series[2].ChartType = SeriesChartType.Point;
        chart1.Series[0].Points.Clear();
        foreach (Point pt in points)
        {
            chart1.Series[0].Points.AddXY(pt.X, pt.Y);
            chart1.Series[1].Points.AddXY(pt.X, pt.Y);
        }
        List<Point> reducedPoints = reducePlotLines(points);
        foreach (Point pt in reducedPoints)
        {
            chart1.Series[2].Points.AddXY(pt.X, pt.Y);
        }
    }
