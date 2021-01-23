    // prepare the test chart..
    chart1.ChartAreas.Clear();
    ChartArea CA = chart1.ChartAreas.Add("CA1");
    Random R = new Random(123);
    chart1.Series.Clear();
    CA.AxisX.MajorTickMark.Interval = 1;
    Series S = chart1.Series.Add("S1");
    S.Points.Clear();
    S.ChartType = SeriesChartType.Column;
    S.SetCustomProperty("PixelPointWidth", "10");
    // some random data:
    DateTime dt0 = new DateTime(2015, 05, 01);
    for (int i = 0; i< 40; i++)
    {
        int p = S.Points.AddXY(dt0.AddHours(i), R.Next(100));
    }
    // each custom label will be placed centered in a range
    // so we need an amount of half an interval..
    // this assumes equal spacing..
    double ih = (S.Points[0].XValue - S.Points[1].XValue) / 2d;
    // now we add a custom label to each data point
    for (int i = 0; i < S.Points.Count; i++)
    {
        DataPoint pt = S.Points[i];
        string s = (DateTime.FromOADate(pt.XValue)).ToString("HH:mm");
        bool midnite = s == "00:00";
                
        if (midnite) s = DateTime.FromOADate(pt.XValue).ToString("dd.MM.yyyy");
        CustomLabel CL = CA.AxisX.CustomLabels.Add(pt.XValue - ih, pt.XValue + ih, s);
        CL.ForeColor = midnite ? Color.Blue : Color.Black;
    }
