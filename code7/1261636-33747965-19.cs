        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = new MyViewModel();
            DataContext = viewModel;
            for (int i = 1; i <= 10; i++)
            {
                viewModel.MyPointCollection1.Add(new Point { X = i, Y = i * 2 });
                viewModel.MyPointCollection2.Add(new Point { X = i, Y = i * 3 });
            }
        }
