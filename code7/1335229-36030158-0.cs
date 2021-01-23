    void PlotDelta(Chart chart, Series S1, Series S2, Series SDelta)
    {
        for (int i = 0; i < S1.Points.Count; i++)
        {
            if ( i < S2.Points.Count)
            {
                DataPoint dp1 = S1.Points[i];
                DataPoint dp2 = S2.Points[i];
                if (!dp1.IsEmpty && !dp2.IsEmpty)
                    SDelta.Points.AddXY(dp1.XValue, dp2.YValues[0] - dp1.YValues[0]);
            }
        }
