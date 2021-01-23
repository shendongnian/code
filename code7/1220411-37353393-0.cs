    class CustomCacheConnection : IDisposable
    {
        private static string connString;
        private static CacheConnection conn;
        private static CacheCommand cmd;
        public CustomCacheConnection(string sql)
        {
            conn = new CacheConnection();
            connString = GetConnectionString();
            cmd = new CacheCommand(sql, conn);
        }
        #region IDisposable Support
        private bool disposed = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    cmd.Dispose();
                    //make sure the connection state is open so we can close it
                    if (conn != null && conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                disposed = true;
            }
        }
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
