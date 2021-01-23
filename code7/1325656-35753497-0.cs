    // No wiggle
            chartNoWiggle.Series[0].Points.AddXY(xdatetime, r.NextDouble());
            if (chartNoWiggle.Series[0].Points.Count > 10)
                chartNoWiggle.Series[0].Points.RemoveAt(0);
            chartNoWiggle.ChartAreas[0].AxisX.Minimum = chartNoWiggle.Series[0].Points[0].XValue;
            chartNoWiggle.ChartAreas[0].AxisX.Maximum = xdatetime.ToOADate();
            xdatetime = xdatetime.AddMinutes(1);
    // Wiggle
            chartWiggle.Series[0].Points.AddXY(xdouble, r.NextDouble());
            if (chartWiggle.Series[0].Points.Count > 10)
                chartWiggle.Series[0].Points.RemoveAt(0);
            chartWiggle.ChartAreas[0].AxisX.Minimum = chartWiggle.Series[0].Points[0].XValue;
            chartWiggle.ChartAreas[0].AxisX.Maximum = xdouble;
            xdouble += 0.10000000001234;
