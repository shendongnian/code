    ChartArea ca1 = chart1.ChartAreas[0];
    // the regular axis label interval and range
    ca1.AxisX.Interval = 10;
    ca1.AxisX.Minimum = 0;
    ca1.AxisX.Maximum = 100;
    // we add an extra chartarea
    ChartArea ca2 = chart4.ChartAreas.Add("ca2");
    // we align it..
    ca2.AlignmentOrientation = AreaAlignmentOrientations.All;
    ca2.AlignWithChartArea = ca1.Name;
    // ..but we also need to set the position
    // we create a hard coded element position that leaves room for labels and legend
    ca1.Position = new ElementPosition(0, 0, 80, 90);  // 80% width
    ca2.Position = new ElementPosition(0, 0, 80, 90);  // 90% height
    // we make the overlayed area transparent
    ca2.BackColor = Color.Transparent;
    // it needs a series to display the overflowing points
    Series S22 = chart4.Series.Add("OverFlow");
    S22.ChartType = SeriesChartType.StepLine;
    S22.Color = Color.Red;
    S22.ChartArea = "ca2";
