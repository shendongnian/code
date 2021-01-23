        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.Series.Add(new Series { Name = "Cos", ChartType = SeriesChartType.Line });
            chart1.Series.Add(new Series { Name = "Sin", ChartType = SeriesChartType.Line });
            chart1.Series.Add(new Series { Name = "Delta", ChartType = SeriesChartType.Line });
            for (int i = 0; i < 100; i++ )
            {
                chart1.Series["Cos"].Points.AddXY(i, Math.Cos(i / Math.PI));
                chart1.Series["Sin"].Points.AddXY(i, Math.Sin(i / Math.PI));
            }
            PlotDelta(chart1, chart1.Series["Cos"], chart1.Series["Sin"],
                              chart1.Series["Delta"]);
        }
