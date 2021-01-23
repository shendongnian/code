    public void DoTransition()
    {
        double from = 0;
        double to = -200;
    
        this.TransitionStoryboard.Stop();
        this.TransitionStoryboard.Children.Clear();
        IEasingFunction easing = new QuadraticEase() { EasingMode = EasingMode.EaseOut };
        DoubleAnimation translateXAnim = new DoubleAnimation() {
            From = from,
            To = to,
            Duration = TimeSpan.FromMilliseconds(250),
            EasingFunction = easing,
        };
    
        // 1. Refer to the element by Name
        Storyboard.SetTargetName(translateXAnim, "pageContentContainerTransform");
        Storyboard.SetTargetProperty(translateXAnim, new PropertyPath(TranslateTransform.XProperty));
        this.TransitionStoryboard.Children.Add(translateXAnim);
        // 2. Pass in the template context here
        this.TransitionStoryboard.Begin(this, this.Template);    
    }
