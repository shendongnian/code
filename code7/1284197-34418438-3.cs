    class MyClass
        {
            private DbConnectionHandler _dbHandler { get; set; }
            public MyClass(DbConnectionHandler dbhandler)
            {
                _dbHandler = dbhandler;
            }
        }
