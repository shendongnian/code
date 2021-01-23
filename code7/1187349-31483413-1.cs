    private void Form1_Load(object sender, EventArgs e)
    {
        Random R = new Random(1);
        List<Tuple<Series, int>> misses = new List<Tuple<Series, int>>();
        chart1.Series.Clear();
        for (int i = 0; i < 3; i++ )
        {
            Series s = new Series("S" + (i + 1));
            s.ChartType = SeriesChartType.Column;
            chart1.Series.Add(s);
        }
        chart1.ChartAreas[0].AxisX.Interval = 1;
        foreach(Series s in chart1.Series)
        {
            for (int i = 0; i < 30; i+=3)
            {
                if (R.Next(3) > 0) s.Points.AddXY(i, i+1);
                else misses.Add(new Tuple<Series, int>(s, i));
            }
        }
        foreach (Tuple<Series, int> m in misses)
        {
            if (m.Item1.Name == "S1") m.Item1.Points.AddXY(m.Item2 + "X", m.Item2 + 5);
            else m.Item1.Points.AddXY(m.Item2, m.Item2 + 5);
        }
        for (int i = 0; i < chart1.Series[0].Points.Count - 1; i++)
        {
            chart1.Series[0].Points[i].AxisLabel = chart1.Series[0].Points[i].XValue + "%";
        }
    }
