        public class MySingleton
        {
            private static Lazy<MySingleton> _instance = new Lazy<MySingleton>(() => new MySingleton());	
        	public static MySingleton Instance { get { return _instance.Value; } }
        	
        	private MySingleton()
        	{
        		
        	}
        }
    At best you can save two of these lines.
