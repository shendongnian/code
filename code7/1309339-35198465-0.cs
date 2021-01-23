    public class MyContext : ...
    {
        public MyContext(string connectionstring)
            : base(connectionstring)
        {
        }
        public static MyContext Create()
        {
            return new MyContext(DbAccessor.ConnectionStringForContext);
        }
    }
