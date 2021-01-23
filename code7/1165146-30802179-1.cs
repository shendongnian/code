    namespace MyWindowsService
    {
    	class Program : ServiceBase
        {
    		static void Main()
            {
    			System.ServiceProcess.ServiceBase.Run(new Program());
    		}
    		
    		// This function is called after windows service starts running
    		protected override void OnStart(string[] args)
            {
    			// Do something
    			
    			base.OnStart(args);
    		}
    		
    		// This function is called when windows service stopping
    		protected override void OnStop()
            {
    			// Do something
    		
    			base.OnStop();
    		}
    	}
    }
