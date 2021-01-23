    var input = string.Empty;
    var lockObj = new Object();
    System.Threading.Timer timer = new System.Threading.Timer(o =>
    {
        string localInput;
        lock(lockObj)
        {
            localInput = input;
            input = string.Empty;
        }
        Console.WriteLine("\noutput: {0}", localInput);
    }, null, System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);   
    while (true)
    {
        var key = Console.ReadKey();
        timer.Change(2000, System.Threading.Timeout.Infinite);
        lock(lockObj)
        {
            input += key.KeyChar;
        }
    }
