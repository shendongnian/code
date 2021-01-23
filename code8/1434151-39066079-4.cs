    private void chart2_PrePaint(object sender, ChartPaintEventArgs e)
    {
        Chart chart = chart2;
        ChartArea ca = chart.ChartAreas[0];
        Series s0 = chart.Series["points"];
        foreach (DataPoint dp in s0.Points)
        {
            PointF pt = PolarValueToPixelPosition(dp, chart, ca);
            e.ChartGraphics.Graphics.DrawEllipse(Pens.OrangeRed, pt.X - 5, pt.Y - 5, 9, 9);
        }
    }
