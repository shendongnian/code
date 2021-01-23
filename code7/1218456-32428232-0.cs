    var mPopup = new ContentDialog()
    {
        Title = "",
        PrimaryButtonText = "OK",
        IsSecondaryButtonEnabled = false,
        Content = new Border()
        {
            HorizontalAlignment = HorizontalAlignment.Stretch,
            BorderThickness = new Thickness(10),
            BorderBrush = new SolidColorBrush(Colors.White),
            Child = new TextBlock()
            {
                Text = "Hello World",
                FontSize = 20,
                Foreground = new SolidColorBrush(Colors.White),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            }
        }
    };
    
    mPopup.ShowAsync();
