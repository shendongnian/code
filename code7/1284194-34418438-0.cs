    public class DbConnectionHandler
        {
            public SqlConnection Connection { get; set; }
            public DbConnectionHandler(string connection)
            {
                Connection = new SqlConnection(connection);
            }
        }
