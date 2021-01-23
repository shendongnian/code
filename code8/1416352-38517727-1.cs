    public class ColoredString
    {
        public ConsoleColor Color;
        public String Text;
        public ColoredString(ConsoleColor color, string text)
        {
            Color = color;
            Text = text;
        }
    }
    public static void WriteConsoleColor(params ColoredString[] strings)
    {
        var originalColor = Console.ForegroundColor;
        foreach (var str in strings)
        {
            Console.ForegroundColor = str.Color;
            Console.Write(str.Text);
        }
        Console.ForegroundColor = originalColor;
    }
    public void DoIt()
    {
        WriteConsoleColor(
            new ColoredString(ConsoleColor.Blue, "My favorite fruit: "),
            new ColoredString(ConsoleColor.Red, "Apple")
        );
    }
