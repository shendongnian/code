    static bool state = true;
    public static void _Main(string[] args)
    {
        Console.WriteLine("1. Main thread: {0}", DateTime.Now.ToString("HH:mm:ss.fffffff"));
        Thread t = new Thread(new ThreadStart(StartLoop));
        t.Start();
        Console.WriteLine("2. Main thread: {0}", DateTime.Now.ToString("HH:mm:ss.fffffff"));
        Thread.Sleep(5000);
        state = false;
        Console.WriteLine("3. Main thread: {0}", DateTime.Now.ToString("HH:mm:ss.fffffff"));
    }
    delegate void MyDelegate(ref bool s);
    public static void StartLoop()
    {
        MyDelegate myDelegate = LoopMethod;
        myDelegate(ref state);
    }
        
    public static void LoopMethod(ref bool state)
    {
        while (state)
        {
            Console.WriteLine("LoopMethod running: {0}", DateTime.Now.ToString("HH:mm:ss.fffffff"));
            Thread.Sleep(1000);
        }
    }
