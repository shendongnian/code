     static void Main(string[] args)
    {
        Do();
    }
    static void Do()
    {
        DosomethingElse();
    }
    private static void DosomethingElse()
    {
        StackTrace stackTrace = new StackTrace();
        foreach (StackFrame Frame in stackTrace.GetFrames())
        {
            Console.WriteLine(Frame);
        }
    }
