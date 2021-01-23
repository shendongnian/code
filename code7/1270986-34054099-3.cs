    private void button7_Click(object sender, EventArgs e)
    {
        chart1.ChartAreas.Clear();
        chart1.Series.Clear();
        ChartArea CA = chart1.ChartAreas.Add("CA");
        Series S1 = chart1.Series.Add("S1");
        S1.ChartType = SeriesChartType.Point;
        DateTime now = DateTime.Now.Date;
        CA.AxisX.Minimum = now.AddHours(-12).ToOADate();
        CA.AxisY.Maximum = 16;
        // create a few test data with values 1-15
        // every couple of days
        Random R = new Random(1);
        for (int i = 0; i < 150; i++)
        {
            DateTime dt = now.AddDays(R.Next(4)+i);
            S1.Points.AddXY(dt, R.Next(16) );
        }
        // call the function that adds the counting axis:
        addSumSeries(chart1, S1);
    }
