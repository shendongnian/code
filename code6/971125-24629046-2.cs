    private static Timer SetTimer()
    {
        _timer = new Timer(2000.0);
        _timer.Elapsed += (sender, args) =>
        {
            lock (Lock)
            {
                DoBackgroundStuff();
            }
        };
        lock (Lock)
        {
            _timer.Enabled = true;    
        }
        return _timer;
     }
