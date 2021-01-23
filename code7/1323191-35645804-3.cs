    private void btnHideAllButtons_Click(object sender, RoutedEventArgs e) {
        gridMain.Children.OfType<Button>()
            .ToList()
            .ForEach(b => b.Visibility = Visibility.Collapsed);
    }
