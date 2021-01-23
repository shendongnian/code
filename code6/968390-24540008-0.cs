    System.Web.UI.DataVisualization.Charting.Series series = new System.Web.UI.DataVisualization.Charting.Series("mySeries");
    series.ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
    
    foreach (SummaryData s in summaryData)
    {                
        series.AddXY(s.DataType, s.Total);
    }
