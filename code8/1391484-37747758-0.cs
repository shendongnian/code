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
    // we want to show a secondary axis on top:
    ca2.AxisX2.Enabled = AxisEnabled.True;
    // don't disable the primary axis if you want any labels!
    // instead make its labels transparent!
    ca2.AxisX.LabelStyle.ForeColor = Color.Transparent;
    // this is shared by the sec.axis event though it has its own property!
    ca2.AxisX.LabelStyle.Interval = 10;
    // I color the axis and the labels
    ca2.AxisX2.LineColor = S22.Color;
    ca2.AxisX2.LabelStyle.ForeColor = S22.Color;
    // we need to set the range for both (!) axes:
    ca2.AxisX2.Minimum = 100;
    ca2.AxisX2.Maximum = 200;
    ca2.AxisX.Minimum = 100;
    ca2.AxisX.Maximum = 200;
