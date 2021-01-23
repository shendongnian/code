    chart1.Series.Clear();
    Series S = chart1.Series.Add("S1");
    S.ChartType = SeriesChartType.Area;
    chart1.ChartAreas[0].AxisX.Minimum = 0;
    for (int i = 0; i <= 2; i++) S.Points.AddXY(i, 0);
    for (int i = 2; i <= 6; i++) S.Points.AddXY(i, 1);
    for (int i = 6; i <= 10; i++) S.Points.AddXY(i, 0);
    for (int i = 10; i <= 20; i++) S.Points.AddXY(i, 1);
    for (int i = 20; i <= 22; i++) S.Points.AddXY(i, 0);
