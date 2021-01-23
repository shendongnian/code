    var dialog = new CustomMessageBox()
    {
        Content = new ListBox(){ItemsSource = source, Height = 800},
        RightButtonContent = "Cancel",
        LeftButtonContent = "Store",
        VerticalContentAlignment = VerticalAlignment.Top, // Change to Top
        VerticalAlignment = VerticalAlignment.Top, // Change to Top
        Background = new SolidColorBrush(Colors.Black),
        HorizontalContentAlignment = HorizontalAlignment.Center,
        HorizontalAlignment = HorizontalAlignment.Center
    };
