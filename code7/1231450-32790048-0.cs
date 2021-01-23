    static class Program
    {
        static void Main()
        {
            #if(!DEBUG)
               ServiceBase[] ServicesToRun;
               ServicesToRun = new ServiceBase[] 
    	   { 
    	        new MyService() 
    	   };
               ServiceBase.Run(ServicesToRun);
            #else
               MyService myServ = new MyService();
               myServ.Process();
               // here Process is my Service function
               // that will run when my service onstart is call
               // you need to call your own method or function name here instead of Process();
            #endif
        }
    }
