    public async Task Main(String[] args)
    {
        #if DNX451
        AppDomain.CurrentDomain.UnhandledException += 
            (s, e) => Console.WriteLine(e);
        #endif
        try
        {
            await Task.Delay(1000);
            Console.WriteLine("After Task.Delay");
        }
        finally
        {
            Console.WriteLine("Inside Finally");
        }
    }
