    static void Main(string[] args)
    {
        YourService service = new YourService();
 
        if (Environment.UserInteractive)
        {
            service.OnStart(args);
            Console.WriteLine("Press any key to stop program");
            Console.Read();
            service.OnStop();
        }
        else
        {
            ServiceBase.Run(service);
        } 
    }
