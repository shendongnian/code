    Series S = chart1.Series[0];
    S.ChartType = SeriesChartType.Line;
    S.Color = Color.Fuchsia;
    S.Points.AddXY(1, 10);    S.Points.AddXY(2, 20);
    S.Points.AddXY(3, 60);    S.Points.AddXY(4, 10);
    DataPoint yourDataPoint = S.Points[2];
    yourDataPoint.Color = Color.Gray;
