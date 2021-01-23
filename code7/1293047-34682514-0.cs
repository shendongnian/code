    static void Main(string[] args)  
    {
        alcAvgPerc a = new CalcAvgPerc();
        while (true)
        {
            Console.WriteLine("Select Shape: (R)ectangle, (C)ircle, (S)quare, (T)riangle:");
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.R:
                    a.Rectangle();
                    break;
                case ConsoleKey.C:
                    a.Circle();
                    break;
                case ConsoleKey.S:
                    a.Square();
                    break;
                case ConsoleKey.T:
                    a.Triangle();
                    break;
                case ConsoleKey.Escape:
                    Console.WriteLine("Exiting...")
                    return;
            }
        }
    }
