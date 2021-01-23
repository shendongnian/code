    Series series = new Series();
    this.crtBytes.Series.Add(series);
    series.SetCustomProperty("PointWidth", "1");
    
    for (int i = 0; i < byteDistribution.Count; i++)
    {
        if (byteDistribution[i] > 0)
        {
            series.Points.AddXY(i, byteDistribution[i]);
            // PointWidth has no affect?
        }
    }
