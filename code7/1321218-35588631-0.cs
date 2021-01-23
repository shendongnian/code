    private void button17_Click(object sender, EventArgs e)
    {
        chart3.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        chart3.Series.Clear();
        Series s1 = chart3.Series.Add("S1");
        Series s2 = chart3.Series.Add("S2");
        Series s3 = chart3.Series.Add("S3");
        Random R = new Random(42);
        s1.ChartType = SeriesChartType.Bar;
        s2.ChartType = SeriesChartType.Bar;
        s3.ChartType = SeriesChartType.Bar;
        for (int i = 0; i < 10; i++)
        {
            // this series is complete..:
            s1.Points.AddXY(i + "", R.Next(100));
            int r = R.Next(5);
            // this series misses some points..:
            if (r==0) s2.Points.AddXY(i + "", R.Next(100));
            // this series inserts empty points and so misses no points.:
            if (r == 0) s3.Points.AddXY(i + "", R.Next(100));
            else { int p = s3.Points.AddXY(i + "", R.Next(100)); s3.Points[p].IsEmpty = true; }
        }
        // now add a value at "10" for all series..;
        s1.Points.AddXY("10", 100);
        s2.Points.AddXY("10", 100);
        s3.Points.AddXY("10", 100);
    }
