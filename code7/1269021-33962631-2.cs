    chart1.Series.Clear();                     
    chart1.ChartAreas.Clear();
    ChartArea CA = chart1.ChartAreas.Add("CA");  
    Series S1 = chart1.Series.Add("S1");
    S1.ChartType = SeriesChartType.Point;
