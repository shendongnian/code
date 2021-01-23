    ..
    Series s3 = chart.Series.Add("S3 ");
    s1.ChartType = SeriesChartType.Spline;
    s2.ChartType = SeriesChartType.Line;
    s3.ChartType = SeriesChartType.SplineArea;
            
    s2.Color = Color.Red;
    s3.Color = Color.FromArgb(55, Color.RosyBrown);
    for (int i = 0; i < 50; i++)
    {
        s1.Points.AddXY(i,20 - rnd.Next(10) );
        s2.Points.AddXY(i,17);
        if (i > 10 && i < 20) s3.Points.AddXY(i, s1.Points[i].YValues[0]);
    }
