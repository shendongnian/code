    public static class StringConsoleHelper
    {
        public static void WriteAt(this string s, int x, int y)
        {
            // save the current position
            var origCol = Console.CursorLeft;
            var origRow = Console.CursorTop;
            // move to where you want to write
            Console.SetCursorPosition(x, y);
            Console.Write(s);
            // restore the previous position
            Console.SetCursorPosition(origCol, origRow);
        }
    }
