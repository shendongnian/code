    private void PhotoButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        AnimateProgressRingSlice(PhotoButtonRotateTransform.Angle + 90);
    }
    private void AnimateProgressRingSlice(double to, double miliseconds = 350)
    {
        var storyboard = new Storyboard();
        var doubleAnimation = new DoubleAnimation();
        doubleAnimation.Duration = TimeSpan.FromMilliseconds(miliseconds);
        doubleAnimation.EnableDependentAnimation = true;
        doubleAnimation.To = to;
        Storyboard.SetTargetProperty(doubleAnimation, "Angle");
        Storyboard.SetTarget(doubleAnimation, PhotoButtonRotateTransform);
        storyboard.Children.Add(doubleAnimation);
        storyboard.Begin();
    }
