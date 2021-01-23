    private static readonly DoubleAnimationUsingKeyFrames BlinkAnimation;
    private static readonly Storyboard BlinkStoryboard;
    static MyClassStaticConstructor()
    {
        BlinkAnimation = new DoubleAnimationUsingKeyFrames();
        BlinkAnimation.KeyFrames.Add(new DiscreteDoubleKeyFrame(1, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
        BlinkAnimation.KeyFrames.Add(new DiscreteDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(250))));
        BlinkStoryboard = new Storyboard
        {
            Duration = TimeSpan.FromMilliseconds(900),
            RepeatBehavior = RepeatBehavior.Forever,
        };
        BlinkStoryboard.Children.Add(blinkAnimation);
    }
    private void BlinkSenderUsername(int index, string userRole)
    {
        // There is no need to instantiate a ListBoxItem
        //ListBoxItem target = new ListBoxItem();
        ListBoxItem target = OnlineUserList.ItemContainerGenerator.ContainerFromIndex(index) as ListBoxItem;
        if (target == null) return; // Just make sure we managed to get a ListBoxItem instance
        OnlineUserList.ScrollIntoView(target);
        Storyboard.SetTarget(BlinkAnimation, target);
        Storyboard.SetTargetProperty(BlinkAnimation, new PropertyPath(OpacityProperty));
        BlinkStoryboard.Begin(target, true);
    }
