     public class ConnectionRepository : IConnectionRepository
    {
        private IDbConnection _cnn = null;
       
        public IDbConnection GetOpenConnection(string databaseName)
        {
            if (_cnn != null && _cnn.ConnectionString.ToLower().Contains(databaseName.ToLower()))
            {
                _cnn.Open();
                return _cnn;
            }
            var cnn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            
            //Now replace database name in connection string with whichever one supplied
            var cb = new SqlConnectionStringBuilder(cnn) { InitialCatalog = databaseName };
            // wrap the connection with a profiling connection that tracks timings 
            return new ProfiledDbConnection(new SqlConnection(cb.ConnectionString), MiniProfiler.Current);
        }
    }
