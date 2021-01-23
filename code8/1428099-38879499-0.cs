    // preparation
    for (int i = 0; i < 4; i++)
    {
        Series s = chart1.Series.Add("S" + i);
        s.ChartType = SeriesChartType.StackedArea;
        Series s2 = chart2.Series.Add("S" + i);
        s2.ChartType = SeriesChartType.SplineArea;
    }
    for (int i = 0; i < 30; i++)   // some test data
    {
        chart1.Series[0].Points.AddXY(i, Math.Abs(Math.Sin(i / 8f)));
        chart1.Series[1].Points.AddXY(i, Math.Abs(Math.Sin(i / 4f)));
        chart1.Series[2].Points.AddXY(i, Math.Abs(Math.Sin(i / 1f)));
        chart1.Series[3].Points.AddXY(i, Math.Abs(Math.Sin(i / 0.5f)));
    }
    // the actual calculations:
    int sCount = chart1.Series.Count; 
    for (int i = 0; i < chart1.Series[0].Points.Count ; i++)
    {
        double v = chart1.Series[0].Points[i].YValues[0];
        chart2.Series[sCount - 1].Points.AddXY(i, v);
        for (int j = 1; j < sCount; j++)
        {
            v += chart1.Series[j].Points[i].YValues[0];
            chart2.Series[sCount - j - 1].Points.AddXY(i, v);
        }
    }
    // optionally control the tension:
    chart9.Series[0].SetCustomProperty("LineTension", "0.15");
