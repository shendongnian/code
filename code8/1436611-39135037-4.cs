    public sealed class Singleton
    {
    	private static readonly object _lock = new object();
        private static Singleton instance = new Singleton();
    
        public static Singleton Instance
        {
            get
            {
    			lock(_lock)
    			{
    				if (instance==null)
    				{
    					instance = new Singleton();
    				}
    				return instance;	
    			}
            }
        }
    
        private Singleton()
        {
        }
    }
