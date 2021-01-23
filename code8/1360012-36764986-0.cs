    Series series1 = new Series("Series1");
        series1.ChartArea = "ca1";
        series1.ChartType = SeriesChartType.Bar;
        series1.Font = new System.Drawing.Font("Verdana", 11f, FontStyle.Regular);
        series1.Points.Add(new DataPoint
        {
            AxisLabel = "A",
            YValues = new double[] { 100 },
            Color = Color.Green,
        });
        series1.Points.Add(new DataPoint
        {
            AxisLabel = "B",
            YValues = new double[] { 324 },
            Color = Color.Red,
        });
        series1.Points.Add(new DataPoint
        {
            AxisLabel = "C",
            YValues = new double[] { 235 },
            Color = Color.Yellow,
        });
