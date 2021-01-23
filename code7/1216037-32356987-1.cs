        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            ObservableCollection<KeyValuePair<double, double>> points = new ObservableCollection<KeyValuePair<double, double>>();
            for (int i = 0; i < 20; i++)
                points.Add(new KeyValuePair<double, double>(i, r.NextDouble()));
            chart1.DataContext = points;
        }
    }
