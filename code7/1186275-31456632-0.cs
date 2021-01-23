    private void Image_Download(object sender, RoutedEventArgs e) {
        Button button = sender as Button;
        if (button != null) {
            Grid grid = button.Parent as Grid;
            if (grid != null) {
                ProgressBar progressBar = grid.Children.OfType<ProgressBar>().FirstOrDefault();
                if (progressBar != null) {
                    progressBar.Visibility = Visibility.Hidden;
                }
            }
        }
    }
