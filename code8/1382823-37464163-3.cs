        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var _bigDataPoints = new List<DataPoint>();
            // #x1 double #y double
            _bigDataPoints.Add(new DataPoint(410.8070281, 4943000.0000000));
            _bigDataPoints.Add(new DataPoint(432.7935746, 5041000.0000000));
            _bigDataPoints.Add(new DataPoint(436.8319199, 5059000.0000000));
            _bigDataPoints.Add(new DataPoint(9918.193582, 47320000.0000000));
            _bigDataPoints.Add(new DataPoint(10099.91912, 48130000.0000000));
            _bigDataPoints.Add(new DataPoint(10216.58243, 48650000.0000000));
            _bigDataPoints.Add(new DataPoint(104904.5616, 470700000.0000000));
            _bigDataPoints.Add(new DataPoint(107282.6983, 481300000.0000000));
            _bigDataPoints.Add(new DataPoint(108337.1551, 486000000.0000000));
            _bigDataPoints.Add(new DataPoint(991388.6853, 4422000128.0000000));
            _bigDataPoints.Add(new DataPoint(1000362.786, 4462000128.0000000));
            _bigDataPoints.Add(new DataPoint(1006195.923, 4488000000));
            var logAxisX = new LogarithmicAxis() { Position = AxisPosition.Bottom, Title = "Log(x)", UseSuperExponentialFormat = false, Base = 10 };
            var linearAxisY = new LinearAxis() { Position = AxisPosition.Left, Title = "Y", UseSuperExponentialFormat = false };
            PlotModel ChartPlot = new PlotModel(); //-> this is property that is binding to oxyplot control
            ChartPlot.Axes.Add(linearAxisY);
            ChartPlot.Axes.Add(logAxisX);
            var lineSeriesBigData = new OxyPlot.Series.LineSeries();
            lineSeriesBigData.Points.AddRange(_bigDataPoints);
            ChartPlot.Series.Clear();
            ChartPlot.Annotations.Clear();
            ChartPlot.Series.Add(lineSeriesBigData);
            // This is the line you're missing
            plotView1.Model = ChartPlot;
        }
