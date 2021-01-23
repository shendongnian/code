    if (i % 2 == 0)
    {
         //iseven
         Console.ForegroundColor = ConsoleColor.Blue;
         Console.WriteLine(new string('&', 30));
    }
    else
    {
        //is odd
        Console.ForegroundColor = ConsoleColor.White; //<--- here.
        Console.WriteLine(new string('*', 30));
    }
