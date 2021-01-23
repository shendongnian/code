    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("test");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter) break;
            else Console.WriteLine("You gave something else");
            
            Console.WriteLine("This is the end of the app");
            break;
        }
    }
