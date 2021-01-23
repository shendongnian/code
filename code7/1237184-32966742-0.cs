    var consoleLock = new object();
    Task.Run(() =>
    {
        for (int i = 0; i <= 1000000; i++)
        {
            Thread.Sleep(1); // to simulate some work
            lock(consoleLock)
            {
                Console.SetCursorPosition(Console.CursorLeft, 0);
                Console.WriteLine(i);
            }
        }
    });
    Task.Run(() =>
    {
        for (int j = 0; j <= 1000000; j++)
        {
            Thread.Sleep(1); // to simulate some work
            lock(consoleLock)
            {
                Console.SetCursorPosition(Console.CursorLeft, 3);
                Console.WriteLine(j);
            }
        }
    });
    Console.ReadLine();
