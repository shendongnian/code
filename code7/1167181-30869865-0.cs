    class Program2
    {
        static void AnimateString(int leftEdge, int RightEdge, int length, char fillWith, string text, int delay_ms)
        {
            int x = RightEdge;
            string line = "";
            int count = 0;
        while (true)
        {
            Console.CursorLeft = 0;
            Console.Write(new String(fillWith, length));
            Console.CursorLeft = 0;
            if (x < leftEdge) ++count;                
            line = new String(fillWith, x - 1 > leftEdge? x - 1 : leftEdge) + text.Substring(x > leftEdge - 1? 0 : count,
                x > leftEdge - 1 ? (x + text.Length > RightEdge ? RightEdge - x : text.Length) : text.Length - count );
            Console.Write(line);
            Thread.Sleep(delay_ms);
            --x;
            if (count >= text.Length) { x = RightEdge; count = 0; line = ""; }
        }       
    }
    static void Main()
    {
        string blank = new String('-', 32);
        string text = "Hello world!";
        AnimateString(4, 20, 24, '-', "Hello world", 100);
        Console.ReadKey();
    }
}
