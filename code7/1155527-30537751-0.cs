    public class BaseEntity
    {
        public BaseEntity()
        {
            // Save current connection string being used to create the entity. 
            // ConnectionManager.Instance.CurrentConnection will be null by the time deserialization happens
            _connectionString = ConnectionManager.Instance.CurrentConnection.ConnectionString;
        }
        private readonly string _connectionString;
        [NotMapped]
        public string MyProperty
        {
             using (var ctx = new MyContext(_connectionString))
                 ...
        }
    }
