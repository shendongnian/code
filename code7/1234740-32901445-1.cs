    IObservable<EventPattern<MouseEventArgs>> mouseTracker = 
        Observable.FromEventPattern<MouseEventArgs>(form1, "MouseMove");
    
    //Will emit the latest value from mouseTracker, every 750 milliseconds
    IObservable<EventPattern<MouseEventArgs>> sampledTracker = 
        mouseTracker.Sample(TimeSpan.FromMilliseconds(750));
    
    sampledTracker
    .ObserveOn(SynchronizationContext.Current)
    .Subscribe(evt =>
    {
        rxLabel.Text = evt.EventArgs.Location.ToString();
    });
