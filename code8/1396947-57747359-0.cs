    static void Main(string[] args)
    {
        bool keepLooping = true;
        while (keepLooping)
        {
            //Do your stuff here
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                keepLooping = false;
            }
        }
    }
