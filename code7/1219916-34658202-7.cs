    ColorAnimation backgroundfade = ClrAnim(CanvasGS2.Color, Color.FromRgb(5, 3, 13), 1, 0.8, 0.1);
    backgroundfade.BeginTime = TimeSpan.FromSeconds(1.3);
    InitialiseInnerMenu.Children.Add(backgroundfade);
    Storyboard.SetTarget(backgroundfade, MainCanvas);
    Storyboard.SetTargetProperty(backgroundfade, new PropertyPath("Background.(GradientBrush.GradientStops)[1].(GradientStop.Color)"));
    CanvasGS2.BeginAnimation(GradientStop.ColorProperty, backgroundfade);
