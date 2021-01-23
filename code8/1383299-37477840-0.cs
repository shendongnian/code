    public class DBConnection
    {
        public DbConnection(IContext context)
        {
            this.Context = context; 
        }
        public IContext Context { get; }
        public String GetConnection()
        {
           return this.Context.GetConfiguration("connectionString");
        }
    }
