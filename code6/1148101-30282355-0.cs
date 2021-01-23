    public static string ReadPassword()
    {
        var pass = "";
        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
                // Stop Receving Keys Once Enter is Pressed
                break;
            // Backspace Should Not Work
            if (key.Key != ConsoleKey.Backspace)
            {
                pass += key.KeyChar;
                Console.Write("*");
            }
            else if (pass.Length > 0)
            {
                pass = pass.Substring(0, (pass.Length - 1));
                Console.Write("\b \b");
            }
        }
        return pass;
    }
