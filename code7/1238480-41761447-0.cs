    private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        btn.Content = "Before pause";
    
        var animation = new DoubleAnimation();
        animation.From = btn.ActualWidth;
        animation.To = 100;
        animation.Duration = TimeSpan.FromSeconds(2);
    
        btn.BeginAnimation(Button.WidthProperty, animation);
    
        await Task.Delay(2000);
    
        btn.Content = "After pause";
    }
