    private void button1_Click(object sender, EventArgs e)
    {
        chart1.Series.Clear();
        Series S = chart1.Series.Add("S1");
        S.ChartType = SeriesChartType.StackedColumn;
        Random R = new Random(123);
        DateTime dt = Convert.ToDateTime("2015-01-01");
        chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd.MM.yy";
        for (int m = 1; m < 12; m++)
        {
            // This can be a real or a dummy point, depending on a simple condition..
            S.Points.AddXY(dt.AddMonths(m), (m <= 2) ? R.Next(100): 0);
        }
    }
