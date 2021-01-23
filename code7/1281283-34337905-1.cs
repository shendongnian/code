    static object loglock = new object();
    static void Main(string[] args)
    {
        var blah = new Blah();
    
        blah.SomeEvent += Log;
    
        Task.Factory.Start(blah.Start);
        var blah2 = new Blah();
    
        blah2.SomeEvent += Log;
    
        Task.Factory.Start(blah2.Start);
    
        Application.Run();
    }
    static void Log(string text, EventArgs e)
    {
        lock(loglock)
        {
            // write to file
        }
    }
