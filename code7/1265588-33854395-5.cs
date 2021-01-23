    private static void EditorFor(string label, string value, int length)
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new String(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, Console.CursorTop);
        int charactersLeftToInput = length - value.Length;
        string placeholder = new String('*', charactersLeftToInput);
            
        Console.Write("{0}: {1}{2}", label, value, placeholder);
        Console.CursorLeft -= charactersLeftToInput;
    }
