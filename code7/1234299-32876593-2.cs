       public class Log
            {
                private string foo;
    
                private static Log instance;
    
                public static Log Instance
                {
                    get
                    {
                        if (instance == null)
                        {
                            throw new InvalidOperationException("Call CreateInstance(-) to create this object");
                        }
                        else
                        {
                            return instance;
                        }
                    }
                }
    
                private Log(string foo) { this.foo = foo; }
    
                public static Log CreateInstance(string foo)
                {
                    return instance ?? (instance = new Log(foo));
                }
            }
