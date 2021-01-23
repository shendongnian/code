    var now = DateTime.UtcNow;
    var nextMinute = now.AddTicks(-(now.Ticks%TimeSpan.TicksPerMinute)).AddMinutes(1);
    DispatcherTimer hourTimer = new DispatcherTimer(DispatcherPriority.Normal)
    {
        Interval = nextMinute - DateTime.UtcNow
    };
    hourTimer.Tick += (sender, e) =>
    {
        var correctionNow = DateTime.UtcNow;
        var timeCorrection = correctionNow.AddTicks(-(correctionNow.Ticks % TimeSpan.TicksPerMinute)).AddMinutes(1);
        hourTimer.Interval = timeCorrection - DateTime.UtcNow;
        renderTime();
    };
    hourTimer.Start();
