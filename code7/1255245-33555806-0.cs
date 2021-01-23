            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Interval = 2;
            Series S1 = chart1.Series.Add("S1");
            Series S2 = chart1.Series.Add("S2");
            S1.ChartType = SeriesChartType.Line;
            S2.ChartType = SeriesChartType.Line;
            Random R = new Random(42);
            for (int i = 0; i < 15; i++)
            {
                int v = R.Next(10);
                S1.Points.AddXY(i, v);
                S2.Points.AddXY(v, i);
            }
