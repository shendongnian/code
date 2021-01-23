            var model = new PlotModel { Title = "AreaSeries" };
            var series = new AreaSeries { Title = "series" };
            for (double x = -10; x <= 10; x++)
            {
                series.Points.Add(new DataPoint(x, (-1 * (x * x) + 50)));
                series.Points2.Add(new DataPoint(x, x));
            }
            series.Color2 = OxyColors.Transparent;
            model.Series.Add(series);
            plotView.Model = model;
