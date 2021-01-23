    static void Main(string[] args)
    {
        TestService = new  TestService ();
    
        #if DEBUG
            TestService.StartWork();
        #else
            System.ServiceProcess.ServiceBase.Run(TestService ); 
        #endif
    }
