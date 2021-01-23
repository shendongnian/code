    public static void RewriteLine(int lineNumber, String newText)
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, currentLineCursor - lineNumber);
        Console.Write(newText); Console.WriteLine(new string(' ', Console.WindowWidth - newText.Length)); 
        Console.SetCursorPosition(0, currentLineCursor);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Text to be rewritten");
        Console.WriteLine("Just some text");
        RewriteLine(2, "New text");
    }
