    Dim counter as int = 0;
    foreach (Series ser in chart.Series)
    {
       ser.Name = "ser" & counter + 1;
       ser.IsVisibleInLegend = false;
       ser.IsXValueIndexed = true;
       ser.XValueType = ChartValueType.Time;
       ser.YAxisType = AxisType.Primary;
       ser.ChartType = SeriesChartType.Line;
       this.chart1.Series.Add(ser);
       counter += 1;
    }
