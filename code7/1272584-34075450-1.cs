    public class ConnectionstringAwareFooRepository : IFooRepository
    {
        private SqlFooRepository repo;
    
        public Foo Read(int id)
        {
            var connectionstring =
                ConfigurationManager.ConnectionStrings["foo"].ConnectionString;
    
            if (this.repo == null ||
                this.repo.ConnectionString != connectionString)
                this.repo = new SqlFooRepository(connectionString);
    
            return this.repo.Read(id);
        }
    }
