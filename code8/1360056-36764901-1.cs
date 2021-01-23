    protected override OnCollectionChanged(NotifyCollectionChangedEventArgs e) {
        // Another event already queued a delayed notification
        if (_isTimerRunning)
            return;
        // Assuming _timer is a System.Timers.Timer object already configured
        // and OnTimerElapsed method attached to its Elapsed event. Note that
        // you may also use System.Threading.Timer, pick the proper one
        // according to MSDN and your requirements
        _isTimerRunning = true;
        _timer.Start(); 
    }
    private void OnTimerElapsed(Object source, ElapsedEventArgs e) {
        _isTimerRunning = false;
        _timer.Stop();
        base.OnCollectionChanged(
            new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }
