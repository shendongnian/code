    var input = string.Empty;
    System.Threading.Timer timer = new System.Threading.Timer(o =>
    {
        Console.WriteLine("\noutput: {0}", input);
        input = string.Empty;
    }, null, System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);   
    while (true)
    {
        var key = Console.ReadKey();
        timer.Change(2000, System.Threading.Timeout.Infinite);
        input += key.KeyChar;
    }
