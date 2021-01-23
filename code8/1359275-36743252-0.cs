    static void Main(string[] args)
    {
        var messages = GetMessagesToPrint();
        Execute(84, 3, messages);
    }
    // Method for which you should write the test method on its output
    private static List<string> GetMessagesToPrint()
    {
        string header = "| LogType         | Message      |          tagCollection |          Time |";
        ...
        ...// actual list of string you want to construct.
        ...
        var messages = new List<string> {"Events", header, new string('-', header.Length)};
        return messages;
    }
    
    //This doesnt need a test method
    public static void Execute(int xOffset, int yOffset, IEnumerable<string> messageToPrint)
    {
        foreach (var message in messageToPrint)
        {
            Console.SetCursorPosition(xOffset, yOffset++);
            Console.WriteLine(message);
        }
    }
