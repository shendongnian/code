    var nextMinute = DateTime.UtcNow.AddMinutes(1);
    nextMinute = nextMinute.AddTicks(-(nextMinute.Ticks%TimeSpan.TicksPerMinute));
    
    DispatcherTimer hourTimer = new DispatcherTimer(DispatcherPriority.Normal)
    {
        Interval = nextMinute - DateTime.UtcNow
    };
    hourTimer.Tick += (sender, e) =>
    {
        var timeCorrection = DateTime.UtcNow.AddMinutes(1);
        timeCorrection = nextMinute.AddTicks(-(timeCorrection.Ticks % TimeSpan.TicksPerMinute));
        hourTimer.Interval = timeCorrection - DateTime.UtcNow;
        renderTime();
    };
    hourTimer.Start();
