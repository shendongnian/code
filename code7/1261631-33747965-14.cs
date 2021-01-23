        int index;
        MyViewModel2 viewModel;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = new MyViewModel2();
            DataContext = viewModel;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PointCollection pc = new PointCollection();
            for (int i = 1; i <= 10; i++)
                pc.Add(new Point { X = i, Y = i * (2 + index) });
            LineSeries series1 = new LineSeries();
            series1.DependentValuePath = "Y";
            series1.IndependentValuePath = "X";
            series1.ItemsSource = pc;
            chart1.Series.Add(series1);
            viewModel.MyList.Add(pc);
            index++;
        }
