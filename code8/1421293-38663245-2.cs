    void AlignSeries(Chart chart)
    {
        var allValues = chart.Series.SelectMany(s => s.Points)
                              .Select(x=>x.XValue).Distinct().ToList();
        foreach (Series series in chart.Series)
        {
            int px = 0;    //insertion index
            foreach(double d in allValues )
            {
                var p = series.Points.FirstOrDefault(x=> x.XValue == d);
                if (p == null)  // this value is missing
                {
                    DataPoint dp = new DataPoint(d, double.NaN);
                    dp.IsEmpty = true;
                    series.Points.Insert(px, dp);
                }
                px++;
            }
        }
    }
