    // get a reference
    ChartArea chartArea1 = chart1.ChartAreas[0];
    // don't start at 0
    chartArea1.AxisX.IsStartedFromZero = false;
    // pick your interval
    chartArea1.AxisX.MajorTickMark.Interval = 1D;
    // set minimum at the middle
    chartArea1.AxisX.Minimum = chartArea1.AxisX.MajorTickMark.Interval / 2d;
    // pick a column width (optional)
    chart1.Series[0].SetCustomProperty("PixelPointWidth", "30");
    // we want the labels to sit with the points, not the grid lines..
    // so we add custom labels for each point ranging between the grid lines..
    for (int i = 0; i <  chart1.Series[0].Points.Count; i++)
    {
        DataPoint dp = chart1.Series[0].Points[i];
        chartArea1.AxisX.CustomLabels.Add( (0.5d + i) * interval, 
                                           (1.5d + i) * interval, dp.XValue.ToString());
    }
