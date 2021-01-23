    // ...
    var animation = new DoubleAnimation()
    {
        BeginTime = TimeSpan.FromSeconds(0),
        Duration = TimeSpan.FromSeconds(5),                
        From = notification.ActualHeight,
        To = 0
    };
    Storyboard.SetTarget(animation, notification);
    Storyboard.SetTargetProperty(animation, new PropertyPath("RenderTransform.Y"));
    sb.Children.Add(animation);
    // ...
