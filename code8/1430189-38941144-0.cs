    Series s = chart1.Series[0];            // a reference to the default series
    ChartArea ca = chart1.ChartAreas[0];  // a reference to the default chart area
    Axis ax = ca.AxisX;
    Axixs ay = ca.AxisY;
    s.ChartType = SeriesChartType.Polar;   // set the charttype of the series
    // a few data to test:
    for (int i = 0; i < 10; i++)
         s.Points.AddXY(i * 10, i + rnd.Next(12));
    ax.Interval = (int)numericUpDown1.Value;
    ay.Interval = (int)numericUpDown2.Value;
    ax.Minimum = (int)numericUpDown3.Value;
    ax.Maximum = (int)numericUpDown4.Value;
    ay.Minimum = (int)numericUpDown5.Value;
    ay.Maximum = (int)numericUpDown6.Value;
