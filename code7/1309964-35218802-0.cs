    static void Main()
        {if DEBUG
            Service1 Myservice = new Service1();
            Myservice.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);endif
        }
