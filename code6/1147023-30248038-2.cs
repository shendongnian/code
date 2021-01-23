    private void chart1_Paint(object sender, PaintEventArgs e)
    {
        if (paintToCalaculate)
        {
            Series s = chart1.Series.FindByName("dummy");
            if (s == null) s = chart1.Series.Add("dummy");
            drawPoints.Clear();
            s.Points.Clear();
            foreach (PointF p in valuePoints)
            {
                s.Points.AddXY(p.X, p.Y);
                DataPoint pt = s.Points[0];
                double x = chart1.ChartAreas[0].AxisX.ValueToPixelPosition(pt.XValue);
                double y = chart1.ChartAreas[0].AxisY.ValueToPixelPosition(pt.YValues[0]);
                drawPoints.Add(new Point((int)x, (int)y));
                s.Points.Clear();
            }
            paintToCalaculate = false;
            chart1.Series.Remove(s);
        }
        //..
        // now we can draw our points at the current positions:
        foreach (Point p in drawPoints)
            e.Graphics.FillEllipse(Brushes.Red, p.X - 2, p.Y - 2, 4, 4);
    }
