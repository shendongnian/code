    chart7.Series["Series3"].ChartType = SeriesChartType.Line;
    chart7.Series["Series3"].Points.DataBindXY(xVal, arrDouble3);
    foreach (Series series in chart7.Series)
    {
       foreach (DataPoint arrP in series.Points)
       {
           if (arrP.YValues.Length > 0 && (double)arrP.YValues.GetValue(0) == 0)
           { 
                arrP.IsValueShownAsLabel = false;                   
           }
        }
     }
     chart7.Series["Series3"].Points.DataBindXY(xVal, arrP);    ????
