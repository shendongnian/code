    ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Blue, ConsoleColor.White };
    char[] messageChars = new char[] { '&', '*' };
            
    for (int i = 0; i < 10; i++)
    {
        Console.ForegroundColor = colors[i % 2];
        Console.WriteLine(new String(messageChars[i % 2], 30));
    }
