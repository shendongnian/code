    if (_timer != null)
    {
        _timer.Stop();
    }
    else
    {
        _timer = new Timer();
        _timer.Interval = 1000;
        _timer.Tick += new EventHandler(_timer_Tick);
    }
    ...
    _timer.Start();
