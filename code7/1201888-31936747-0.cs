    public void Pulse()
    {
        var storyboard = new Storyboard
        {
            FillBehavior = FillBehavior.Stop,
            RepeatBehavior = new RepeatBehavior(2)
        };
    
        double timeIncrement = .15;
    
        double growPercent = 20;
        double shrinkPercent = -20;
    
        var firstTime = TimeSpan.FromSeconds(timeIncrement);
        var secondTime = TimeSpan.FromSeconds(timeIncrement * 3);
        var thirdTime = TimeSpan.FromSeconds(timeIncrement * 4);
    
        var scale = new ScaleTransform(1.0, 1.0);
    
        RenderTransformOrigin = new Point(.5, .5);
        RenderTransform = scale;
    
        storyboard = AddSizeChange(firstTime, growPercent, storyboard);
        storyboard = AddSizeChange(secondTime, shrinkPercent, storyboard);
        storyboard = AddSizeChange(thirdTime, growPercent, storyboard);
        
        BeginStoryboard(storyboard, HandoffBehavior.SnapshotAndReplace, false);
    }
    public Storyboard AddSizeChange(TimeSpan animTime, double changePercent, Storyboard storyboard)
    {
        DoubleAnimation growX = new DoubleAnimation
        {
            Duration = animTime,
            To = 1 + changePercent
        };
        storyboard.Children.Add(growX);
        Storyboard.SetTargetProperty(growX, new PropertyPath("RenderTransform.ScaleX"));
    
        DoubleAnimation growY = new DoubleAnimation
        {
            Duration = animTime,
            To = 1 + changePercent
        };
        storyboard.Children.Add(growY);
        Storyboard.SetTargetProperty(growY, new PropertyPath("RenderTransform.ScaleY"));
    
        return storyboard;
    }
