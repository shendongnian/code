    void ChangeBackground(object sender, RoutedEventArgs e)
    {
        if (btn.Background == Brushes.Red)
        {
            btn.Background = new LinearGradientBrush(Colors.LightBlue, Colors.SlateBlue, 90);
            btn.Content = "Control background changes from red to a blue gradient.";
        }
        else
        {
            btn.Background = Brushes.Red;
            btn.Content = "Background";
        }
    }
