    public class Singleton
    { 
        static Singleton s_myInstance = null;
        private Singleton()
        {
        }
        // Very simplistic implementation (not thread safe, not disposable, etc)
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
