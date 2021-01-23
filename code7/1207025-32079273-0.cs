    public static event EventHandler TestEvent;
    
    private static EventHandler saved = (s, e) => DoSomething();
    static void Main(string[] args)
    {
        TestEvent += saved;
        TestEvent -= saved;
    }
    internal static void DoSomething()
    {
    }
