    abstract class DbDataReader
    {
        // ...
    }
    
    class SqlDataReader : DbDataReader
    {
    }
    
    // ...
    
    class SqlConn : Conn 
    {
        public override Dictionary<string, DbDataReader> GetData()
        {
           return new Dictionary<string, DbDataReader>
           {
                { "Key", new SqlDataReader() } 
           }
        }
    }
