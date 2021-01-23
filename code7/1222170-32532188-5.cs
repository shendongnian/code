    Console.Write(myText[i]);
    if (pauseTime > 0)
    {
        var key = Reader.ReadKey(pauseTime);
        if (key != null && key.Key == ConsoleKey.Enter)
        {
            pauseTime = 0;
        }
    }
