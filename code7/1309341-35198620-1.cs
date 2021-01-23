    public MyContext(string connectionstring)
            : base(connectionstring)
    {
        public static MyContext CreateContextDBOne()
        {
            return new MyContext(DbAccessor.ConnectionStringForDBOne);
        }
    
        public static MyContext CreateContextDBTwo()
        {
            return new MyContext(DbAccessor.ConnectionStringForDBTwo);
        }
    }
