    static void errhandler(object sender, UnhandledExceptionEventArgs args)
    {
        Console.WriteLine("Errhandler called");
        Exception e = (Exception)args.ExceptionObject;
        Console.WriteLine(e.StackTrace + ' ' + e.ToString());
        System.Environment.Exit(1);
    }
    public static void Main(string[] args)
    {
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(errhandler);
        string s = null;
        s.ToString();
    }
