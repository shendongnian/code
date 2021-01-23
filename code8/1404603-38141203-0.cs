    public static char YorN(string prompt)
    {
        Console.Write(prompt + " ");
        while (true)
        {
            char input = char.ToUpper(Console.ReadKey().KeyChar);
            if (input == 'Y' || input == 'N')
            {
                Console.WriteLine();
                return input;
            }
            Console.Write("\b \b"); // Use backspace ('\b') to erase the incorrect character.
        }
    }
