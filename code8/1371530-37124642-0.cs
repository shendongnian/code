    int _countDown = 180;
    void Start() 
    {
        var timer = new System.Timer.Timer(1000);   // Duration in milliseconds
        timer.Elapsed += async ( sender, e ) => await HandleTimer();
        timer.Start();   
    }
    void HandleTimer()
    {
        _countDown--;
        Console.WriteLine("Time Left: " + _countDown.ToString());
    }
