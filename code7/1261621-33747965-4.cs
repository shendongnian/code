        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = new MyViewModel2();
            DataContext = viewModel;
            PointCollection pc1 = new PointCollection();
            PointCollection pc2 = new PointCollection();
            for (int i = 1; i <= 10; i++)
            {
                pc1.Add(new Point { X = i, Y = i * 2 });
                pc2.Add(new Point { X = i, Y = i * 3 });
            }
            LineSeries series1 = new LineSeries();
            series1.DependentValuePath = "Y";
            series1.IndependentValuePath = "X";
            series1.ItemsSource = pc1;
            chart1.Series.Add(series1);
            viewModel.MyList.Add(pc1);
            LineSeries series2 = new LineSeries();
            series2.DependentValuePath = "Y";
            series2.IndependentValuePath = "X";
            series2.ItemsSource = pc2;
            chart1.Series.Add(series2);
            viewModel.MyList.Add(pc2);
        }
