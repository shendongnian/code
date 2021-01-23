    previewItem.ShowTimer = new DispatcherTimer
    {
        Interval = TimeSpan.FromMilliseconds(previewItem.HandleList[0].Duration)
    };
    previewItem.ShowTimer.Tick += (s, ee) =>
    {
        // create your logic for the tick event here:
        previewItem.DoSomething();
    };
    previewItem.ShowTimer.Start();
