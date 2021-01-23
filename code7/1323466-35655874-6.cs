    private void btnStar_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        var item = btn.Tag as Item;
        item.ButtonColor = item.ButtonColor == Brushes.Gray ? Brushes.Yellow : Brushes.Gray;
    }
