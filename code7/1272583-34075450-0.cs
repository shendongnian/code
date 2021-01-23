    public class SqlFooRepository : IFooRepository
    {
        private const string connectionString;
    
        public SqlFooRepository(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");
    
            this.connectionString = connectionString;
        }
        public string ConnectionString
        {
            get { return this.connectionString; }
        }
    
        public Foo Read(int id)
        {
            // SQL query code goes here...
        }
    }
