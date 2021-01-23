    // prepare:
    chart1.Series.Clear();
    Series S1 = chart1.Series.Add("S1");
    ChartArea CA = chart1.ChartAreas[0];
    // style type, font, color, axes
    S1.ChartType = SeriesChartType.Bar;
    CA.BackColor = Color.AliceBlue;
    chart1.BackColor = CA.BackColor;
    Font f = new Font("Consolas", 10f);
    CA.AxisX.LabelStyle.Font = f;
    S1.BackGradientStyle = GradientStyle.TopBottom;
    CA.AxisX.MajorGrid.Enabled = false;
    CA.AxisX.MajorTickMark.Enabled = false;
    CA.AxisX.LineColor = Color.Transparent;
    CA.AxisY.Enabled = AxisEnabled.False;
    CA.AxisY.MajorGrid.Enabled = false;
    CA.AxisY.MajorTickMark.Enabled = false;
