    public static string ReadOnlyNumbers()
    {
        StringBuilder input = new StringBuilder();
        ConsoleKeyInfo ckey;
    
        while ((ckey = Console.ReadKey(true)).Key != ConsoleKey.Enter)
        {
            if (Char.IsDigit(ckey.KeyChar))
            {
                Console.Write(ckey.KeyChar);
                input.Append(ckey.KeyChar);
            }
            if (ckey.Key == ConsoleKey.Backspace)
            {
                input.Length--;
                Console.Write("\b \b");
            }
        }
    
        Console.Write(Environment.NewLine);
        return input.ToString();
    }
