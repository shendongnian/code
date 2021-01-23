    #if DEBUG
                YourService service = new YourService();
                service.OnDebug();
            
                // This prevents timeouts while debugging  
                System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
    #else
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                            new YourService()
                };
                ServiceBase.Run(ServicesToRun);
    #endif
