    class Program
    {
        public static void Main(string[] args)
        {
            var example = new MyExampleApp();
            if (args.Length == 1 && args[0].Equals("--console"))
            {
                example.ConsoleRun();
            }
            else
            {
                ServiceBase.Run(example);
            }
        }
    }
    
    class MyExampleApp : ServiceBase
    {
    
        public void ConsoleRun()
        {
            Console.WriteLine(string.Format("{0}::starting...", GetType().FullName));
    
            OnStart(null);
    
            Console.WriteLine(string.Format("{0}::ready (ENTER to exit)", GetType().FullName));
            Console.ReadLine();
    
            OnStop();
    
            Console.WriteLine(string.Format("{0}::stopped", GetType().FullName));
        }
    
        //... the rest of the code from your service class.
    }
