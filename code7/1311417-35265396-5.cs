    sealed class ADBShell 
    {
    
        public static string output = String.Empty;
    
        private ABDShell _instance;
        private Process _processInstance;
    
         // Note: constructor is 'private'
    
        private ADBShell()
        {
    
    
        }
    
        public Process ProcessInstance
         {
              if(_processInstance==null)
               _processInstance = new Process();
               get _processInstance ;
         }
    
        public static ADBShell Instance
        {
            get
            {
              
                if (_instance == null)
                {
                    
                    _instance = new ABDShell();
                }
                return _instance;
            }
        }
    }
