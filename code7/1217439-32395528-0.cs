    class Program
    {
        static int Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; ;
            if (args.Any() && args[0] == "/t")
            {
                Console.WriteLine("I am going to throw an exception");
                throw new ApplicationException("This is an exception");
            }
            else
            {
                Console.WriteLine("I am going to exit");
                //Environment.Exit(0);
                return 0;
            }
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("An unexpected error has occurred");
            Exception ex = (Exception)e.ExceptionObject;
            Environment.Exit(ex.HResult);
        }
    }
