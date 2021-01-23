    public class Singleton  
    {
        private Singleton()
        {
        }
        private static Singleton instance = new Singleton();
        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }
    }
    
