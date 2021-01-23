    // Sealed class makes sure it is not inherited. If inheritance required, go to Abstract Pattern.
    class ADBShell
    {
        //public static property used to expose Singleton instance.
        public static ADBShell Instance;
   
    
        // private constructor
        private ADBShell() { }
        public static ADBShell getInstance()
        {
            if (Instance == null)
            {
                Instance = new Process;
            }
        }
    }
