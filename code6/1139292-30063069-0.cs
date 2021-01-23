    public void AnimateToPoint(UIElement image, Point point, int durationInMilliseconds = 300)
    {
        var duration = new Duration(TimeSpan.FromMilliseconds(durationInMilliseconds));
        var sb = new Storyboard
        {
            Duration = duration
        };
        var animateTop = new DoubleAnimation
        {
            From = Canvas.GetTop(image),
            To = point.Y,
            Duration = duration
        };
        Storyboard.SetTargetProperty(animateTop, new PropertyPath("Canvas.Top")); // You can see that I made some change here because I had an error with what you gave me
        Storyboard.SetTarget(animateTop, image);
        sb.Children.Add(animateTop);
        sb.Begin();
    }
