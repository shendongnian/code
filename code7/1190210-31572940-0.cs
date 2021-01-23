    // Declare the following usings
    using System.Windows;
    using System.Windows.Forms.DataVisualization.Charting;
    using System.Collections.Generic;
    ...
        private void LoadLineChartData()
        {
            Chart myChart = new Chart();
            myChart.Series.Add("ls1");
            myChart.Series["ls1"].ChartType = SeriesChartType.Line;
            myChart.Series["ls1"].MarkerStyle = MarkerStyle.None;
            KeyValuePair<int, int>[] pairs =
            {
                new KeyValuePair<int, int>(1, 100),
                new KeyValuePair<int, int>(2, 130),
                new KeyValuePair<int, int>(3, 150),
                new KeyValuePair<int, int>(4, 125),
                new KeyValuePair<int, int>(5, 155)
            };
            foreach (var pair in pairs)
                myChart.Series["ls1"].Points.AddXY(pair.Key, pair.Value);
        }
