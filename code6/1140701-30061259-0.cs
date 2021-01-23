    private void chart1_AxisViewChanged(object sender, ViewEventArgs e)
    {
        // for a test the result is shown in the Form's title
        Text = "AVG:" + GetAverage(chart1, chart1.Series[0], e);
    }
    double GetAverage(Chart chart, Series series, ViewEventArgs e)
    {
        ChartArea CA = e.ChartArea;  // short..
        Series S = series;           // references  
        // the first and last DataPoints:
        DataPoint pt0 = S.Points.Select(x => x)
                            .Where(x => x.XValue >= CA.AxisX.ScaleView.ViewMinimum)
                            .DefaultIfEmpty(S.Points.First()).First();
        DataPoint pt1 = S.Points.Select(x => x)
                            .Where(x => x.XValue <= CA.AxisX.ScaleView.ViewMaximum;)
                            .DefaultIfEmpty(S.Points.Last()).Last();
        double sum = 0;
        for (int i = S.Points.IndexOf(pt0); i < S.Points.IndexOf(pt1); i++) 
             sum += S.Points[i].YValues[0];
        return sum / (S.Points.IndexOf(pt1) - S.Points.IndexOf(pt0));
    }
