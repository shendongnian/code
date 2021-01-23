    public static void MoveTo(UIElement target, double x, double y)
    {
        var duration = TimeSpan.FromSeconds(5);
        target.BeginAnimation(Canvas.LeftProperty, new DoubleAnimation(x, duration));
        target.BeginAnimation(Canvas.TopProperty, new DoubleAnimation(y, duration));
    }
