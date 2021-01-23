    public static class DBConfiguation
        {
            string _connection = null;
    
            public string Connection {
                get
                {
                    if (_connection == null)
                    {
                        //... you load code
                    }
                    return _connection;
                }
                set
                {
                    _connection = value;
                }
        
            }
        }
