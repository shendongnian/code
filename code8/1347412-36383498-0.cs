    private void timer_Tick(object sender, EventArgs e)
    {
        NumericTimeDataPoint ndp1 = new NumericTimeDataPoint(DateTime.Now, rnd, "ilk", false);
        NumericTimeDataPoint ndp2 = new NumericTimeDataPoint(DateTime.Now, 5.0, "iki", false);
        _series.Points.Add(ndp1);
        _series.Points.Add(ndp2);
    }
