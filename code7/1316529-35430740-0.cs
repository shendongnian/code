    static void Main(string[] args)
    {
        // attach mentioned handlers
        AppDomain.CurrentDomain.UnhandledException += 
            (sender, e) => Dump("Unhandled exception", e.ExceptionObject);
        AppDomain.CurrentDomain.FirstChanceException += 
            (sender, e) => Dump("First chance exception intercepted", e.Exception);
        // this will get intercepted by the FirstChanceException handler
        try
        {
            throw new InvalidOperationException("Thrown inside try/catch");
        }
        catch (Exception ex)
        {
            Console.WriteLine("This was caught: " + ex.Message);
        }
        // this will get intercepted by the FirstChanceException handler
        // and then caught by UnhandledException handler
        throw new InvalidOperationException("Thrown OUTSIDE try/catch");
    }
    private static void Dump(string info, object exception)
    {
        var ex = (Exception)exception;
        Console.WriteLine(info + ": " + ex.Message);
    }
