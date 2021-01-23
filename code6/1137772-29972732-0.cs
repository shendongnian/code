        // add a new Series:
        Series sz = chart1.Series.Add("Zeroes");
        sz.ChartType = SeriesChartType.Point;
        sz.Color = Color.Red;
        sz.BorderWidth = 3;
        // add Points wherever the other series is zero or less
        foreach (DataPoint dp in chart1.Series[0].Points )
        {
            if (dp.YValues[0] <= 0) sz.Points.AddXY(dp.XValue, 0);
        }
