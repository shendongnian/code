    private void styleTestButton_Click(object sender, RoutedEventArgs e)
    {
        var dynamicStyle = new Style();
        dynamicStyle.TargetType = typeof(Button);
        dynamicStyle.Setters.Add(new Setter(BackgroundProperty, Colors.Blue));
        dynamicStyle.Setters.Add(new Setter(MarginProperty, new Thickness(5, 5, 5, 5)));
        styleTestButton.Style = dynamicStyle;
    }
