    public IAsyncResult BeginCalculate(int decimalPlaces, AsyncCallback ac, object state)
    {
        Console.WriteLine("Calling BeginCalculate on thread {0}", Thread.CurrentThread.ManagedThreadId);
        Task<string> f = Task<string>.Factory.StartNew(_ => Compute(decimalPlaces), state);
        if (ac != null) f.ContinueWith((res) => ac(f));
        return f;
    }
    public string Compute(int numPlaces)
    {
        Console.WriteLine("Calling compute on thread {0}", Thread.CurrentThread.ManagedThreadId);
        // Simulating some heavy work.
        Thread.SpinWait(500000000);
        // Actual implemenation left as exercise for the reader.
        // Several examples are available on the Web.
        return "3.14159265358979323846264338327950288";
    }
    public string EndCalculate(IAsyncResult ar)
    {
        Console.WriteLine("Calling EndCalculate on thread {0}", Thread.CurrentThread.ManagedThreadId);
        return ((Task<string>)ar).Result;
    }
