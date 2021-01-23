    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (StateToggle.IsChecked == true)
        {
            StateToggle.Content = "\u00BB";
            foreach (FrameworkElement element in MenuPanel.Children)
                element.LayoutTransform = new RotateTransform(-90);
        }
        else
        {
            StateToggle.Content = "\u00AB";
            foreach (FrameworkElement element in MenuPanel.Children)
                element.LayoutTransform = null;
        }
    }
