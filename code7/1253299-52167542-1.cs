    static void Main(string[] args)
    {
        ConsoleKeyInfo cki;
        Console.WriteLine("Press Esc to exit the loop");
        do
        {
            cki = Console.ReadKey(true);
            if (cki.Modifiers.HasFlag(ConsoleModifiers.Control))
            {
                Console.Write("CTRL ");
            }
            if (cki.Modifiers.HasFlag(ConsoleModifiers.Alt))
            {
                Console.Write("ALT ");
            }
            if (cki.Modifiers.HasFlag(ConsoleModifiers.Shift))
            {
                Console.Write("SHIFT ");
            }
            Console.WriteLine(cki.Key.ToString());
        } while (cki.Key != ConsoleKey.Escape);
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
