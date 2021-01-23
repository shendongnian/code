    private void AnimateProgressBar()
    {
        var storyboard = new Storyboard();
        var animation = new DoubleAnimation { Duration = TimeSpan.FromSeconds(2), From = 1000, To = 0, EnableDependentAnimation = true };
        Storyboard.SetTarget(animation, this.ProgressBar);
        Storyboard.SetTargetProperty(animation, "Value");
        storyboard.Children.Add(animation);
        storyboard.Begin();
    }
