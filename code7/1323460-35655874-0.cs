    private void btnStar_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        btn.Background = btn.Background == Brushes.Gray ? Brushes.Yellow : Brushes.Gray;
    }
