    DateTime endTime = DateTime.Now.AddSeconds(10);
    while (DateTime.Now < endTime)
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                // do something with key
                //...
                // stop waiting
                break;
            }
        }
        // sleep to stop your program using all available CPU
        Thread.Sleep(0);
    }
