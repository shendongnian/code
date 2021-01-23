    class SqlDataContext : ISqlDataContext {
        private readonly SqlConnection _connection;
        public SqlDataContext(string connectionString)
        {
            _connection = CreateConnection(connectionString);
        }
        public IDataReader ExecuteReader(string storedProcedureName, ICollection<SqlParameter> parameters)
        {
           // execute the command here using the _connection private field.
           // This is where your conn.Open() and "do stuff" happens.
        }
        private SqlConnection CreateConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("connectionString");
            }
            return new SqlConnection(connectionString);
        }
    }
    interface ISqlDataContext
    {
        IDataReader ExecuteReader(string storedProcedureName, ICollection<SqlParameter> parameters);
    }
