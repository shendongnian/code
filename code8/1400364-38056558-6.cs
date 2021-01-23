    class MyDBObject 
    { 
        private const string fmt = "Server={0};Database={1};UID={2};PWD={3};";
        ...
        public DB2Connection GetConnection()
        {
            return new DB2Connection(string.Format(fmt,
                        DBServer,DBName,UserCode,Password));
        }
    }
