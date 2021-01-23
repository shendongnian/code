    /// <summary>
    /// Writes to the Console. Does not terminate line, subsequent write is on right of same line.
    /// </summary>
    /// <param name="color">The color that you want to write to the line with.</param>
    /// <param name="text">The text that you want to write to the console.</param>
    public static void ColoredConsoleWrite(ConsoleColor color, string text)
    {
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = originalColor;
    }
    /// <summary>
    /// Writes to the Console. Terminates line, subsequent write goes to new line.
    /// </summary>
    /// <param name="color">The color that you want to write to the line with.</param>
    /// <param name="text">The text that you want to write to the console.</param>
    public static void ColoredConsoleWriteLine(ConsoleColor color, string text)
    {
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = originalColor;
    }
