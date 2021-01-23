    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bmp = getChartImage();
            bmp.Save("yourpathandfilename.png");
            bmp.Dispose();
        }
        static Bitmap getChartImage()
        {
            Chart chart = new Chart();
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);
            chart.ClientSize = new Size(800, 500);
            // a few test data 
            for (int s = 0; s < 5; s++)
            {
                Series series = chart.Series.Add(s.ToString("series 0"));
                series.ChartType = SeriesChartType.Line;
            }
            for (int s = 0; s < 5; s++)
                for (int p = 0; p < 50; p++)
                    chart.Series[s].Points.AddXY(p, s * p);
            Bitmap bmp = new Bitmap(chart.ClientSize.Width, chart.ClientSize.Height);
            chart.DrawToBitmap(bmp, chart.ClientRectangle);
            return bmp;
        }
    }
