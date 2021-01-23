    static void Main(string[] args)
    {
        bool keepLooping = true;
        while (keepLooping)
        {
            //Do your stuff here
            keepLooping = Console.ReadKey().Key != ConsoleKey.Escape;
        }
    }
