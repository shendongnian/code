    Chart chart = new Chart();
    ChartArea CA = chart.ChartAreas.Add("A1");
    Series S1 = chart.Series.Add("S1");
    S1.ChartType = SeriesChartType.Pie;
    S1.Points.AddXY(1, 17);
    S1.Points.AddXY(2, 27);
    S1.Points.AddXY(3, 7);
    S1.Points.AddXY(4, 49);
    chart.BackColor = Color.Fuchsia;
    CA.BackColor = chart.BackColor;
    CA.Area3DStyle.Enable3D = true;
    S1.Points[2]["Exploded"] = "true";
    Bitmap bmp = new Bitmap(chart.Width, chart.Height);
    chart.AntiAliasing = AntiAliasingStyles.None;
    chart.DrawToBitmap(bmp, chart.ClientRectangle);
    bmp.MakeTransparent(chart.BackColor);
    bmp.Save("d:\\chart.png", ImageFormat.Png);
