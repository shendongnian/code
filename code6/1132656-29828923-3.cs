    // two shortcuts
    ChartArea CA = chart1.ChartAreas[0];
    Series S = chart1.Series[0];
    // these are the X-Values of the zoomed portion:
    double min = CA.AxisX.ScaleView.ViewMinimum;
    double max = CA.AxisX.ScaleView.ViewMaximum;
    
    // these are the respective DataPoints:
        DataPoint pt0 = S.Points.Select(x => x)
                         .Where(x => x.XValue >= min)
                         .DefaultIfEmpty(S.Points.First()).First();
        DataPoint pt1 = S.Points.Select(x => x)
                         .Where(x => x.XValue <= max)
                         .DefaultIfEmpty(S.Points.Last()).Last();
    // test output:
    for (int i = S.Points.IndexOf(pt0); i < S.Points.IndexOf(pt1); i++)
        Console.WriteLine(i + " :  " + S.Points[i]);
