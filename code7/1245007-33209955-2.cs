    ConsoleKeyInfo cki = Console.ReadKey(true);
    switch (cki.Key)
    {
        case ConsoleKey.Enter:
            Console.WriteLine("Enter key has been pressed");
            break;
        case ConsoleKey.Escape:
            Console.WriteLine("Escape key has been pressed");
            break;
        default:
            Console.WriteLine("Please press Enter or Esc");
            break;
    }
