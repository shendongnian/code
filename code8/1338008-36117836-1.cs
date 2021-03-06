    ChartArea CA = chart1.ChartAreas[0];
    Series S1 = chart1.Series[0];
    S1.ChartType = SeriesChartType.Line;
    CA.AxisX.Maximum = 100;
    CA.AxisX.Minimum = -100;
    CA.AxisY.Maximum = 100;
    CA.AxisY.Minimum = -100;
    CA.AxisX.Crossing = 0;
    CA.AxisY.Crossing = 0;
    CA.AxisX.LineWidth = 3;
    CA.AxisY.LineWidth = 3;
    CA.AxisX.MajorGrid.Enabled = false;
    CA.AxisY.MajorGrid.Enabled = false;
    // now we add a few points:
    S1.Points.AddXY(-21,81);
    S1.Points.AddXY(52,60);
    S1.Points.AddXY(-53, -11);
    S1.Points.AddXY(-53, 88);
