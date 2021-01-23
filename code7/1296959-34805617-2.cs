    private void _CloseSlideGrid(Storyboard sb)
    {
        DoubleAnimation da = new DoubleAnimation();
        da.Duration = TimeSpan.FromSeconds(0.3d);
        da.DecelerationRatio = 1.0d;
        da.From = 500.0d;
        da.To = 0.0d;
        Storyboard.SetTarget(da, MyTextBox);
        Storyboard.SetTargetProperty(da, new PropertyPath("Width"));
        sb.Children.Add(da);
    }
    private void _DisableTransparentCover(Storyboard sb)
    {
        ColorAnimation ba = new ColorAnimation();
        ba.Duration = TimeSpan.FromSeconds(0.3d);
        ba.DecelerationRatio = 1.0d;
        ba.From = (Color)ColorConverter.ConvertFromString("#77000000");
        ba.To = (Color)ColorConverter.ConvertFromString("#00000000");
        Storyboard.SetTarget(ba, MyGrid);
        Storyboard.SetTargetProperty(ba, new PropertyPath("(Background).(SolidColorBrush.Color)"));
        sb.Children.Add(ba);
    }
    private void _NavCloseButton_Click(object sender, RoutedEventArgs e)
    {
        var sb = new Storyboard();
        _CloseSlideGrid(sb);
        _DisableTransparentCover(sb);
        sb.Begin();
    }
