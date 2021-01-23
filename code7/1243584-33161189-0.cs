    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        Rectangle rett = new Rectangle();
        rett.Fill = new SolidColorBrush(Colors.LightBlue);
        // NOTE: technically don't need to set these, as Stretch is the default value!
        rett.HorizontalAlignment = HorizontalAlignment.Stretch;
        rett.VerticalAlignment = VerticalAlignment .Stretch;
        // 10 pixels of margin on top and left, none on right and bottom
        rett.Margin = new Thickness(10, 10, 0, 0);
        grid1.Children.Add(rett);
    }
