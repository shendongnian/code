    public class Singleton
    { 
        static Singleton s_myInstance = null;
        private Singleton()
        {
        }
        public Singleton Instance 
        {
            get 
            { 
                 if (s_myInstance == null) 
                       s_myInstance = new Singleton();
                 return s_myInstance;
            }
         }
         // More ordinary members here. 
    }
