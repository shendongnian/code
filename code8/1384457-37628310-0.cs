    // no legend:
    chart.Legends.Clear();
    // a couple of short references:
    ChartArea ca = chart.ChartAreas[0];
    Series S1 = chart.Series[0];
    // no y-axis:            
    ca.AxisY.Enabled = AxisEnabled.False;
    ca.AxisY.Minimum = 0;
    ca.AxisY.Maximum = 1;
    // use your own values:
    ca.AxisX.Minimum = 0;
    ca.AxisX.Maximum = 100;
    // style the ticks, use your own values:
    ca.AxisX.MajorTickMark.Size = 7;
    ca.AxisX.MajorTickMark.Interval = 10;
    ca.AxisX.MinorTickMark.Enabled = true;
    ca.AxisX.MinorTickMark.Size = 3;
    ca.AxisX.MinorTickMark.Interval = 2;
    // I turn the axis labels off.
    ca.AxisX.LabelStyle.Enabled = false;
    // If you want to show them pick a reasonable Interval!
    ca.AxisX.Interval = 1;
    // no gridlines
    ca.AxisY.MajorGrid.Enabled = false;
    ca.AxisX.MajorGrid.Enabled = false;
    // the most logical type
    // note that you can change colors, sizes, shaps and markerstyles..
    S1.ChartType = SeriesChartType.Point;
    // display x-value above; make sure you have enough room!
    S1.Label = "#VALX";
    // a few test data:
    S1.Points.AddXY(1, 0.1);
    S1.Points.AddXY(11, 0.1);
    S1.Points.AddXY(17, 0.1);
    S1.Points.AddXY(81, 0.1);
