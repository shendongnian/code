    private void OnOverviewClick(object sender, RoutedEventArgs e)
    {
        // for all buttons in WrapPanelGreen, reset background to default value we used
        foreach (var child in WrapPanelGreen.Children)
        {
            var b = child as Button;
            if (b != null)
            {
                SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                mySolidColorBrush.Color = Color.FromArgb(255, 101, 173, 241);
                b.Background = mySolidColorBrush;
            }
        }
        // the rest of your code
    }
