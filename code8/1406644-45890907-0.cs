        private void Line(Point start, Point end)
        {
            chart1.Series.Add("line");
            chart1.Series["line"].ChartType = SeriesChartType.Line;
            chart1.Series["line"].Color = System.Drawing.Color.Red;
            chart1.Series["line"].Points.AddXY(start.X, start.Y);
            chart1.Series["line"].Points.AddXY(end.X, end.Y);
        }
