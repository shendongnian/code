       public sealed class Factory
        {
            public static IDataContextAsync GetDataContext()
            {
                if (DateTime.Now.Hour > 10)
                {
                    return new DB1Context();
                }
                else
                {
                    return new DB2Context();
    
                }
            }
        }
    
