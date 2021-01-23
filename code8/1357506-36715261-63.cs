    DataPoint curPoint = null;
    private void chart1_MouseUp(object sender, MouseEventArgs e)
    {
        curPoint = null;
    }
    private void chart1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button.HasFlag(MouseButtons.Left))
        {
            ChartArea ca = chart1.ChartAreas[0];
            Axis ax = ca.AxisX;
            Axis ay = ca.AxisY;
            HitTestResult hit = chart1.HitTest(e.X, e.Y);
            if (hit.PointIndex >= 0) curPoint = hit.Series.Points[hit.PointIndex];
            if (curPoint != null)
            {
                Series s = hit.Series;
                double dx = ax.PixelPositionToValue(e.X);
                double dy = ay.PixelPositionToValue(e.Y);
                curPoint.XValue = dx;
                curPoint.YValues[0] = dy;
            }
    }
