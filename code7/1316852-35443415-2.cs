    public static void PressAnyKey()
    {
        Console.WriteLine("Stroke Keys!");
        do
        {
            var mykey = Console.ReadKey(true); //Read The Key
            switch (mykey.Key)
            {
                case ConsoleKey.UpArrow:
                    Console.WriteLine("UpArrow Pressed");
                    //do your stuff
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("DownArrow Pressed");
                    //do your stuff
                    break;
                case ConsoleKey.RightArrow:
                    Console.WriteLine("RightArrow Pressed");
                    //do your stuff
                    break;
                case ConsoleKey.LeftArrow:
                    Console.WriteLine("LeftArrow Pressed");
                    //do your stuff
                    break;
            }
        } while (true);
    }
