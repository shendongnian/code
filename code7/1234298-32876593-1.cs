      public class Log
            {
                private static Log instance;
    
                private Log() { }
    
                public static Log Instance
                {
                    get           
                    {
                        return instance ?? (instance = new Log());              
                    }
                }
            }
