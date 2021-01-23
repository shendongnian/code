    System.Threading.Timer timer = null;
    var input = string.Empty;
    while (true)
    {
        var key = Console.ReadKey();
        if (timer != null ) { timer.Dispose(); }
        timer = new System.Threading.Timer(o =>
        {
            // do something with value...
            Console.WriteLine("\noutput: {0}", input);   // for example...
            input = string.Empty;
        }, null, 2000, System.Threading.Timeout.Infinite);
        input += key.KeyChar;
    }
