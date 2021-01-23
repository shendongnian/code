    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (StateToggle.IsChecked == true)
        {
            StateToggle.Content = "\u00BB";
            MenuPanel.LayoutTransform = new RotateTransform(-90);
            MenuPanel.Orientation = Orientation.Horizontal;
        }
        else
        {
            StateToggle.Content = "\u00AB";
            MenuPanel.LayoutTransform = null;
            MenuPanel.Orientation = Orientation.Vertical;
        }
    }
