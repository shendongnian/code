    private static void PrintColored<T>(string caption, params T[] values)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(caption + " = ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(String.Join(", ", values));
    }
