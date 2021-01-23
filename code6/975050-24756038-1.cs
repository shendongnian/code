    public class ConnectionClass : IDisposable
    {
        private SqlConnection conn;
        private void Connect()
        {
            if (conn == null)
            {
                // connect
            }
        }
        public SqlCommand CreateCommand(string spName)
        {
            Connect();
            return this.conn.CreateCommand(StoredProcedure, spName);
        }
        public void Dispose()
        {
            if (conn != null)
            {
                conn.Dispose();
                conn = null;
            }
        }
    }
