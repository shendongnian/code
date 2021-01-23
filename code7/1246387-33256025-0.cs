    DoubleAnimation da = new DoubleAnimation()
    {
      SpeedRatio = 3.0,
      AutoReverse = false,
      From = 0 
      To = 100
      BeginTime = TimeSpan.FromSeconds(x),
    };
    Storyboard.SetTarget((Timeline)doubleAnimation, YOUR IMAGE);
    Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Top)"));
