    private StackPanel CreateUI(string imagePath, string username)
    {
        StackPanel userStack = new StackPanel()
        {
            Orientation = System.Windows.Controls.Orientation.Horizontal,
            HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
            Margin = new Thickness(36, 24, 0, 0)
        };
        Image profilePic = new Image()
        {
            Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute)),
            Name = "imgProfile",
            Height = 100,
            Width = 100,
            Margin = new Thickness(0, 0, 6, 0)
        };
        TextBlock userName = new TextBlock()
        {
            Text = username,
            Name = "txblkUserName",
            Foreground = new SolidColorBrush(Colors.White),
            FontSize = 32,
            Margin = new Thickness(0, 12, 0, 0)
        };
        userStack.Children.Add(profilePic);
        userStack.Children.Add(userName);
        return userStack;
    }
