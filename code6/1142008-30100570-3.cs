    using System.Windows.Forms.DataVisualization.Charting;
    ...
    ...
    void sumSeries(Chart chart)
    {
        List<Series> dataSeries = chart.Series.ToList();
        Series sumSeries = chart.Series.Add("Total");
        // insert charttype and styles here!
        for (int i = 0; i < dataSeries[0].Points.Count; i++)
        {
            double sum = 0d;
                
            foreach (Series s in dataSeries)
            {
                sum += s.Points[i].YValues[0];
            }
            DataPoint dp = new DataPoint();
            dp.XValue = dataSeries[0].Points[i].XValue;
            dp.YValues[0] = sum;
            sumSeries.Add(dp);
        }
    }
