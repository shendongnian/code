    <Button Margin="50" Click="Button_Click">click</Button>
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        dynamic chrome = VisualTreeHelper.GetChild(button, 0);
        if (chrome != null && chrome.GetType().Name == "ButtonChrome")
        {
            chrome.RenderDefaulted = false;
        }
    }
