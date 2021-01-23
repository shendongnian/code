    chart1.Series.Clear();
    ChartArea CA = chart1.ChartAreas[0];
    // the series with all the points
    Series SP = chart1.Series.Add("SPoint");
    SP.ChartType = SeriesChartType.Point;
    SP.LegendText = "Data points";
    // and the series with a few (visible) lines:
    Series SL = chart1.Series.Add("SLine");
    SL.ChartType = SeriesChartType.Line;
    SL.Color = Color.DarkOrange;
    SL.LegendText = "Connections";
