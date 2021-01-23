    private ElapsedEventHandler _onTimer;
    public void robberyCountdown(User player)
    {
        time = 10;
        _onTimer = (source, e) => OnTimer(player)
        cd.Elapsed += _onTimer;
        cd.Start();
    }
    
    public void OnTimer(User player)
    {
        cd.Stop();
        cd.Elapsed -= _onTimer;
    }     
