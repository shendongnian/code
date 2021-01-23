    void addSpike(Series s, int index, double spikeWidth)
    {
        DataPoint dp = s.Points[index];
        DataPoint dp1 = new DataPoint(dp.XValue + spikeWidth, dp.YValues[0]);
        s.Points.Insert(index+1, dp1);
        s.Points.Insert(index+2, dp);
    }
    void addLine(Series s, int index, double spikeDist, double spikeWidth)
    {
        DataPoint dp = s.Points[index];
        DataPoint dp1 = new DataPoint(dp.XValue + spikeDist, dp.YValues[0]);
        DataPoint dp2 = new DataPoint(dp.XValue + spikeWidth, dp.YValues[0]);
        DataPoint dp0 = dp.Clone();
        dp1.Color = Color.Transparent;
        dp2.Color = dp.Color;
        dp2.BorderWidth = 2;             // optional
        dp0.Color = Color.Transparent;
        s.Points.Insert(index + 1, dp1);
        s.Points.Insert(index + 2, dp2);
        s.Points.Insert(index + 3, dp0);
    }
