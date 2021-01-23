    static void Main(string[] args)
    {
        Console.Clear();
        Console.Write("Enter your name and press ENTER.  (ESC to cancel): ");
        string name = readLineWithCancel();
        Console.WriteLine("\r\n{0}", name == null ? "Cancelled" : name);
        Console.ReadLine();
    }
    private static string readLineWithCancel()
    {
        string result = null;
        StringBuilder buffer = new StringBuilder();
        //The key is read passing true for the intercept argument to prevent
        //any characters from displaying when the Escape key is pressed.
        ConsoleKeyInfo info = Console.ReadKey(true);
        while (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.Escape)
        {
            Console.Write(info.KeyChar);
            buffer.Append(info.KeyChar);
            info = Console.ReadKey(true);
        } 
        if (info.Key == ConsoleKey.Enter)
        {
            result = buffer.ToString();
        }
        return result;
    }
