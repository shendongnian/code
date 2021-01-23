            var model = new PlotModel { Title = "AreaSeries" };
            var series = new AreaSeries { Title = "integral" };
            for (double x = -10; x <= 10; x++)
            {
                series.Points.Add(new DataPoint(x, (-1 * (x * x) + 50)));
            }
            model.Series.Add(series);
