    Chart chart = chart2;
    chart.Series.Clear();
    ChartArea ca = chart.ChartAreas[0];
    Axis ax = ca.AxisX;
    Axis ay = ca.AxisY;
    ax.Minimum  = 0;
    ax.Maximum  = 360;
    ax.Interval = 15;   // 15° interval
    ax.Crossing = 0;    // start the segments at the top!
    ay.Minimum  = 0;
    ay.Maximum  = 10;
    ay.Interval = 1;
    Series s0 = chart.Series.Add("points");
    s0.MarkerStyle = MarkerStyle.Circle;   
    s0.SetCustomProperty("PolarDrawingStyle", "Marker");
    s0.MarkerSize = 6; // pixels
    s0.MarkerColor = Color.Teal;
    s0.ChartType = SeriesChartType.Polar;
    for (double vx = ax.Minimum; vx < ax.Maximum; vx += ax.Interval)
        for (double vy = ay.Minimum; vy <= ay.Maximum; vy += ay.Interval)
            s0.Points.AddXY(vx, vy);
    // you can style each DatAPoint independently:
    s0.Points[333].MarkerColor = Color.Red;
    s0.Points[333].MarkerSize = 12;
