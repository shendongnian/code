    Console.WriteLine("Minutes?");
    string minutes = Console.ReadLine();
    int mins = int.Parse(minutes);
    for (int i = 0; i < mins; i++)
    {
        // Sixty seconds is one minute.
        System.Threading.Thread.Sleep(1000 * 1);
        // Write line.
        if (i % 2 == 0)
        {
            //iseven
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string('&', 30));
        }
        else
        {
            //is odd
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('*', 30));
        }
    }
    // Beep ten times.
    for (int i = 0; i < 10; i++)
    {
        Console.Beep(200, 1000);
    }
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("[Done]");
    Console.Read();
