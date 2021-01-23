    var dp = new DataPoint(8D, 12D);
    dp.Color = Color.Red;
    dp.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
    var series = this.chart1.Series[0];
    series.Points.Add(dp);
