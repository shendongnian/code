    float topF = 0;
    
    foreach (Control viewControl in Panel.Controls)
    {    
        var chartControl = viewControl as ChartControl;
        if (chartControl == null)
            continue;
    
        var chart = new XRChart();
        foreach (ISeries series in chartControl.Series)
        {
            var s = new Series(series.Name, ViewType.Bar);
            s.Points.Add(
                new SeriesPoint(
                    series.Points.First().UserArgument.ToString(), 
                    series.Points.First().UserValues.FirstOrDefault()
                )
            );
            chart.Series.Add(s);
        }
        chart.TopF = topF; // Indent chart.
        topF = chart.BottomF; // Set next value to the topF.
        myReport.Detail.Controls.Add(chart);    
    }
