    static ManualResetEvent signal;
    static void Main(string[] args)
    {
        iTunesApp = new iTunesAppClass();
        iTunesApp.OnPlayerPlayEvent += ITunesApp_OnPlayerPlayEvent;
    
        signal = new ManualResetEvent(false);
        signal .WaitOne();
    }
    
    public static void Stop()
    {
        signal.Set();
    }
    
    private static void ITunesApp_OnPlayerPlayEvent(object iTrack)
    {
    
        var currentArtist = iTunesApp.CurrentTrack.Artist;
        if (currentArtist != LastArtist)
        {
            LastArtist = currentArtist;
            var message = GetMessage(currentArtist);
            UpdateSkypeStatus(message);
            UpdateLog(message);
        }
    }
