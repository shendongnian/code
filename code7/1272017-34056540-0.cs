    private void Clickable(object sender, RoutedEventArgs e)
    {
        if(sender.Name == "button")
    {
        button.Content = FindResource("image1");
    }
    else{
     button_Copy.Content = FindResource("image1");
    }
    }
