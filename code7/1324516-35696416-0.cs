    Series Minimum= chart1.Series.Add("Minimum");
    Minimum.Points.DataBindXY(list_A, list_B);
    Minimum.ChartType = SeriesChartType.Line;
    Minimum.Color = Color.Red;
    Minimum.BorderWidth = 3;  
  
