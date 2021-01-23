    static private readonly object _sync = new object();
    private static void UpdateProgress(int y, string item, int progress, int total)
    {
        int percentage = (int)100.0 * progress / total;
        lock(_sync)
        {
            Console.CursorLeft = 0;
            Console.CursorTop = y;
            Console.Write(item + " [" + new string('=', percentage / 2) + "] " + percentage + "%");
        }
    }
