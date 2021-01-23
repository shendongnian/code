    chart1.Series.Clear();
    string seriesName1 = "stock";
    Series ser1 =  chart1.Series.Add(seriesName1);
   
    ser1.ChartArea = chart1.ChartAreas[0].Name;
    ser1.Name = seriesName1;
    ser1.ChartType = SeriesChartType.Stock;
    ser1.BorderWidth = 3;
    ser1.Points.AddXY(1, 44, 11, 34, 37);  // x, high, low, open, close
    ser1.Points.AddXY(2, 33, 11, 22, 33);
           
    string seriesName2 = "line";
    Series ser2 = chart1.Series.Add(seriesName2);
    
    ser2.ChartArea = chart1.ChartAreas[0].Name;
    ser2.Name = seriesName2;
    ser2.ChartType = SeriesChartType.Line;
    ser2.Points.AddXY(1, 44);
    ser2.Points.AddXY(2, 33);
