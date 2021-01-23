    namespace Exec
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            /// 
            //Create a new instance of ModuleHandler. Only one must exist.
            public static ModuleHandler _modHandler = new ModuleHandler();
    
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                //Initialize the modules. Now the modules will be loaded.
              _modHandler.InitializeModules();
  
    
              Application.Run(_modHandler.Host as Form);
                
      
            }
        }
    }
