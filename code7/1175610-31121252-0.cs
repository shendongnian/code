    var loadingAnimation = new DoubleAnimation(0.01, 1, new Duration(TimeSpan.FromSeconds(0.5)));
    var closingAnimation = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(3)))
    {
        BeginTime = TimeSpan.FromSeconds(5)
    };
    Storyboard.SetTarget(loadingAnimation, AssociatedObject);
    Storyboard.SetTarget(closingAnimation, AssociatedObject);
    Storyboard.SetTargetProperty(loadingAnimation, new PropertyPath(UIElement.OpacityProperty));
    Storyboard.SetTargetProperty(closingAnimation, new PropertyPath(UIElement.OpacityProperty));
    Storyboard.SetTarget(loadingAnimation, AssociatedObject);
    Storyboard.SetTarget(closingAnimation, AssociatedObject);
    var storyboard = new Storyboard();
    storyboard.Children.Add(loadingAnimation);
    storyboard.Children.Add(closingAnimation);
    // Subscription to events must be done at this point, because the Storyboard object becomes frozen later on
    storyboard.Completed += HandleOnCompleted;
    string storyBoardName = "BeginNotificationStoryboard";
    // We define the BeginStoryBoard action for the EventTrigger
    var beginStoryboard = new BeginStoryBoard();
    beginStoryboard.Name = storyBoardName;
    beginStoryboard.Storyboard = storyboard;
    // We create the EventTrigger
    var eventTrigger = new EventTrigger(Control.LoadedEvent);
    eventTrigger.Actions.Add(beginStoryboard);
    // Actions for the entering animation
    var enterSeekStoryboard = new SeekStoryboard
    {
        Offset = TimeSpan.FromSeconds(5),
        BeginStoryboardName = storyBoardName
    };
    var enterPauseStoryboard = new PauseStoryboard
    {
        BeginStoryboardName = storyBoardName
    };
    // Actions for the exiting animation
    var exitSeekStoryboard = new SeekStoryboard
    {
        Offset = TimeSpan.FromSeconds(5),
        BeginStoryboardName = storyBoardName
    };
    var exitResumeStoryboard = new ResumeStoryboard
    {
        BeginStoryboardName = storyBoardName
    };
    var trigger = new Trigger
    {
        Property = UIElement.IsMouseOverProperty,
        Value = true
    };
    trigger.EnterActions.Add(enterSeekStoryboard);
    trigger.EnterActions.Add(enterPauseStoryboard);
    trigger.ExitActions.Add(exitSeekStoryboard);
    trigger.ExitActions.Add(exitResumeStoryboard);
    var style = new Style();
    // The name of the Storyboard must be registered so the actions can find it
    style.RegisterName(storyBoardName, beginStoryboard);
    // Add both the EventTrigger and the regular Trigger
    style.Triggers.Add(eventTrigger);
    style.Triggers.Add(trigger);
    AssociatedObject.Style = style;
    // No need for storyboard.Begin()
