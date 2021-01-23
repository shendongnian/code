    internal class Program
    {
        private static void Main(string[] args)
        {
            var appMgr = new ApplicationManager();
            // pass --console and it runs as console!
            if (args.ToList().Contains("--console")) 
            {
                appMgr.Start();
                Console.Read();  // blocking here until key press
                appMgr.Stop();
            }
            else
            {
                var winService = new WinService(appMgr);
                ServiceBase.Run(winService);
            }
        }
    }
