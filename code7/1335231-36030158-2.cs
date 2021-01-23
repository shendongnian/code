        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            Series S1 = chart1.Series.Add("Cos");
            Series S2 = chart1.Series.Add("Sin");
            Series S3 = chart1.Series.Add("Delta");
            S1.ChartType = SeriesChartType.Line;
            S2.ChartType = SeriesChartType.Line;
            S3.ChartType = SeriesChartType.Line;
            for (int i = 0; i < 100; i++ )
            {
                S1.Points.AddXY(i, Math.Cos(i / Math.PI));
                S2.Points.AddXY(i, Math.Sin(i / Math.PI) );
            }
            PlotDelta(chart1, S1, S2, S3);
        }
