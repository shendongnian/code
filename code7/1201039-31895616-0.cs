    // prepare:
    chart1.Series.Clear();
    Series S1 = chart1.Series.Add("S1");
    ChartArea CA = chart1.ChartAreas[0];
    // style type, font. color, axes
    Font f = new Font("Consolas", 10f);
    S1.ChartType = SeriesChartType.Bar;
    CA.BackColor = Color.LightBlue;
    S1.BackGradientStyle = GradientStyle.HorizontalCenter;
    CA.AxisY.MajorGrid.Enabled = false;
    CA.AxisX.MajorGrid.Enabled = false;
    CA.AxisX.MajorTickMark.Enabled = false;
    CA.AxisY.MajorTickMark.Enabled = false;            
    CA.AxisX.LabelStyle.Font = f;
