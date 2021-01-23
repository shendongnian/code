    public static void ClearC() {
        System.Console.CursorTop = System.Console.CursorTop - 1;
        System.Console.Write(new string(' ', System.Console.BufferWidth));
        System.Console.CursorTop = System.Console.CursorTop - 1;
    }
