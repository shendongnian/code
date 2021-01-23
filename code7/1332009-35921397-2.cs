    private HashSet<Player> _timedPlayers = new HashSet<Player>();
    public MyClass() // or whatever your constructor is called
    {
        cd.Elapsed += OnTimer;
    }
    public void OnTimer(Object source, ElapsedEventArgs e)
    {
        foreach(var player in _timedPlayers)
        {
            // ...
        }
    }
    public void robberyCountdown(User player)
    {
        time = 10;
        _timedPlayers.Add(player);
        cd.Start();
    }
    
    public void OnTimer(User player)
    {
        cd.Stop();
        _timedPlayers.Remove(player);
    }     
