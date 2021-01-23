    static void SetConsoleBackgroundColor(string statement)
    {
        var colorName = Regex.Match(statement, "Color\\.(.+)").Groups[1].Value;
        var color = (ConsoleColor) Enum.Parse(typeof (ConsoleColor), colorName);
        Console.BackgroundColor = color;
    }
    
    static void Main()
    {
        SetConsoleBackgroundColor("objectControl.BackColor = Color.Red");
        Console.WriteLine("Hello, World!");
        Console.ReadKey();
    }
