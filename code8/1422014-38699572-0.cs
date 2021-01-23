    public static async Task SlideUp(FrameworkElement element, double duration, int to = 0)
    {
        var tempTransform = new TranslateTransform();
        element.RenderTransform = tempTransform;
        double from = element.ActualHeight*2;
        duration *= 1.5;
        var animation = new DoubleAnimationUsingKeyFrames();
        animation.KeyFrames.Add(new DiscreteDoubleKeyFrame
        {
            KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0,0,0,0)),
            Value = from
        });
        var ks = new KeySpline { ControlPoint1 = new Point(0.0, 0.0), ControlPoint2 = new Point(0.9, 0.1) };
        animation.KeyFrames.Add(new SplineDoubleKeyFrame
        {
            KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(duration*1000/2)),
            KeySpline = ks,
            Value = (from - to) / 3 + to
        });
        var ks2 = new KeySpline { ControlPoint1 = new Point(0.1, 0.9), ControlPoint2 = new Point(0.2, 1.0) };
        animation.KeyFrames.Add(new SplineDoubleKeyFrame
        {
            KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(duration)),
            KeySpline = ks2,
            Value = to
        });
        Storyboard.SetTargetProperty(animation, "Y");
        Storyboard.SetTarget(animation, tempTransform);
        var sb = new Storyboard();
        sb.Duration = animation.Duration;
        sb.Children.Add(animation);
        sb.Begin();
    }
