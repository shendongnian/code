    static void Main()
    {
    #if (!DEBUG)
        //RELEASE FLAG  
        System.ServiceProcess.ServiceBase[] ServicesToRun;
        ServicesToRun = new System.ServiceProcess.ServiceBase[] { new MyService() };
        System.ServiceProcess.ServiceBase.Run(ServicesToRun);
    #else
        //DEBUG                
        MyService service = new MyService(); //<--Put breakpoint here before you run your service
        service.OnStart(null);    
        System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
    #endif 
    }
