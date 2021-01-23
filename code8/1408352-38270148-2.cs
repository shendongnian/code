    var green = new SolidColorBrush(Colors.Green);
    var transparent = new SolidColorBrush(Colors.Transparent);
    private void GridViewRow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
        var row = sender as GridViewRow;
        if (row.Background == green) {
            row.Background = transparent;
        } else {
            row.Background = green;
        }
    }
