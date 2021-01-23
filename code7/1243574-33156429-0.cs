    while (someLoopCondition)
    {
        //Do lots of work here
        if (Console.KeyAvailable)
        {
            var consoleKey = Console.ReadKey(true);  //true keeps the key from
                                                     //being displayed in the console
            if (consoleKey.Key == ConsoleKey.Escape)
            {
                //Pause here, ask a question, whatever.
            }
        }
    }
